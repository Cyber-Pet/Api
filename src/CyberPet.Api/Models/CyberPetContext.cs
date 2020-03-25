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
        public CyberPetContext(DbContextOptions<CyberPetContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

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
                new User { Id = Guid.Parse("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), Email = "ghmeyer0@gmail.com", Name = "Gabriel Helko Meyer", Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                new User { Id = Guid.Parse("62d41afc-2e81-4b5f-9efe-be14c26d8958"), Email = "gustavoreinertbsi@gmail.com", Name = "Gustavo Reinert", Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", CreateAt = DateTime.Now, UpdateAt = DateTime.Now },
                new User { Id = Guid.Parse("3e3a3c48-3939-49d3-8ada-81936239a609"), Email = "rrschiavo@gmail.com", Name = "Renato Schiavo", Password = "4edc2113d0937fcc5f79c2f3af0a6aa30fa8fb545bfed7d06693d2c909399600", CreateAt = DateTime.Now, UpdateAt = DateTime.Now }
            );

            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = Guid.Parse("56714b09-8040-4af5-a984-c21e69fadb42"), PetName = "Woody", UserId = Guid.Parse("bfbd39c6-76cb-4f49-8351-09ac4b64cb9c"), CreateAt = DateTime.Now, UpdateAt = DateTime.Now }
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
