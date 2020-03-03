using MongoDB.Driver;

namespace CyberPet.Api.Models
{
    public class CyberPetDatabase
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        public CyberPetDatabase(string connectionString)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase("CyberPetDatabase");
            
            Users = _database.GetCollection<User>("Users");
            Pets = _database.GetCollection<Pet>("Pets");
        }

        public IMongoCollection<User> Users { get; set; }
        public IMongoCollection<Pet> Pets { get; set; }
    }
}
