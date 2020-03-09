using CyberPet.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CyberPet.Api
{
    public static class SqliteCyberPetContextFactory
    {
        public static CyberPetContext GetCyberPetContext()
        {
            var options = new DbContextOptionsBuilder<CyberPetContext>()
                         .UseSqlite("Data Source=" + Guid.NewGuid() + ".db")
                         .Options;
            var context = new CyberPetContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;

        }
    }
}
