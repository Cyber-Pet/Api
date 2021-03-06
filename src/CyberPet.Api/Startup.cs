using AutoMapper;
using CyberPet.Api.Configuration;
using CyberPet.Api.Models;
using CyberPet.Api.Models.Interfaces;
using CyberPet.Api.Repositories;
using CyberPet.Api.Repositories.Interfaces;
using CyberPet.Api.Services;
using CyberPet.Api.Services.Interfaces;
using CyberPet.Api.Workers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace CyberPet.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, PetRespository>();

            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();

            services.AddScoped<IBowlService, BowlService>();
            services.AddScoped<IBowlRepository, BowlRepository>();

            services.AddHostedService<ScheduleWorker>();

            services.AddScoped<INotifier, Notifier>();

            services.AddAutoMapper(typeof(AutoMapperConfiguration));
            services.AddDbContext<CyberPetContext>(options =>

                options.UseNpgsql(Configuration.GetConnectionString("CyberPetDatabase"))
            );

            services.AddControllers(o =>
            {
                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "O valor '{0}' n�o � v�lido para {1}.");
                o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "N�o foi fornecido um valor para o campo {0}.");
                o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Campo obrigat�rio.");
                o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "� necess�rio que o body na requisi��o n�o esteja vazio.");
                o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((x) => "O valor '{0}' n�o � v�lido.");
                o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "O valor fornecido � inv�lido.");
                o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "O campo deve ser um n�mero.");
                o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => "O valor fornecido � inv�lido para {0}.");
                o.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) => "O valor fornecido � inv�lido para {0}.");
                o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "O campo {0} deve ser um n�mero.");
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "O valor nulo � inv�lido.");
            })
            .ConfigureApiBehaviorOptions(options =>
             {
                 options.SuppressModelStateInvalidFilter = true;
             });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cyber-Pet API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("SecuritSettings:Secret").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UpdateDatabase(app);
            app.UseDeveloperExceptionPage();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cyber-Pet V1");
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<CyberPetContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
