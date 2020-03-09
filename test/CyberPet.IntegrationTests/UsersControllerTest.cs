using CyberPet.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xunit;

namespace CyberPet.IntegrationTests
{
    public class UsersControllerTest : BaseHttpTest
    {
       
        public class ReadAllAsync : UsersControllerTest
        {
            protected override void ConfigureServices(IServiceCollection services)
            {
                services.AddDbContext<CyberPetContext>(options =>
                    options.UseInMemoryDatabase(databaseName: "InMemoryCyberPetDb")
                );

            }
            [Fact]

            public async Task deve_retornar_os_usuarios()
            {
                var result = await Client.GetAsync("v1/users");
                result.EnsureSuccessStatusCode();
                Assert.NotNull(result);
                
                var users = JsonConvert.DeserializeObject<User[]>(await result.Content.ReadAsStringAsync());
                Assert.Equal(0, users.Length);
            }
        }
    }
}
