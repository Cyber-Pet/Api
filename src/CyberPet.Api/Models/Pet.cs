using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CyberPet.Api.Models
{
    public class Pet
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string PetName { get; set; }
        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;


    }
}
