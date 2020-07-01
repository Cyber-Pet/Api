using CyberPet.Api.Models.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CyberPet.Api.Models
{
    public class CyberPetContext : DbContext
    {
        private Func<object, object> p;

        public CyberPetContext(DbContextOptions<CyberPetContext> options) : base(options)
        {
        }

        public CyberPetContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=tuffi.db.elephantsql.com;Database=raxfebkw;Username=raxfebkw;Password=DJSQIizE-07MwsVQSt_sWWTG_mtPC55A");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Bowl> Bowls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(p => p.Pets)
                .WithOne(u => u.User)
                .HasForeignKey(p => p.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pet>()
                .HasOne(b => b.Bowl)
                .WithOne(p => p.Pet)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Pet>()
                .HasMany(s => s.Schedules)
                .WithOne(p => p.Pet)
                .HasForeignKey(s => s.PetId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.HasPostgresEnum<DayOfWeek>();


            modelBuilder.Entity<User>().HasData(
                new User { Id = Guid.Parse("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), Email = "ghmeyer0@gmail.com", Name = "Gabriel Helko Meyer", Password = "590a70c919b118d0dbd2e9eb8dd2e76b1bf43fcd41018f02c119f79d22a6d5f3", CreateAt = new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local), UpdateAt = new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local), Role ="admin" },
                new User { Id = Guid.Parse("62d41afc-2e81-4b5f-9efe-be14c26d8958"), Email = "gustavoreinertbsi@gmail.com", Name = "Gustavo Reinert", Password = "590a70c919b118d0dbd2e9eb8dd2e76b1bf43fcd41018f02c119f79d22a6d5f3", CreateAt = new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local), UpdateAt = new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local), Role = "user" },
                new User { Id = Guid.Parse("3e3a3c48-3939-49d3-8ada-81936239a609"), Email = "rrschiavo@gmail.com", Name = "Renato Schiavo", Password = "590a70c919b118d0dbd2e9eb8dd2e76b1bf43fcd41018f02c119f79d22a6d5f3", CreateAt = new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local), UpdateAt = new DateTime(2020, 4, 17, 20, 10, 23, 115, DateTimeKind.Local), Role = "user" }
            );

            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = Guid.Parse("56714b09-8040-4af5-a984-c21e69fadb42"), PetName = "Woody", UserId = Guid.Parse("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), CreateAt = new DateTime(2020, 4, 20, 14, 42, 17, 444, DateTimeKind.Local), UpdateAt = new DateTime(2020, 4, 20, 14, 42, 17, 444, DateTimeKind.Local) }
                );

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is CoreModel && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                (entityEntry.Entity as CoreModel).UpdateAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    (entityEntry.Entity as CoreModel).CreateAt = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync();
        }
    }
}
