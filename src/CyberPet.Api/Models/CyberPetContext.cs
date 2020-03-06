using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CyberPet.Api.Models
{
    public class CyberPetContext : DbContext
    {
        public CyberPetContext(DbContextOptions<CyberPetContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }

        
    }
}
