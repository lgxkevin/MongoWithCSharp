using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoWithCsharp
{
    public class PersonModel
    {
        [BsonId]
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressModel AddressDetail { get; set; }
        [BsonElement("DOB")]
        public DateTime DateOfBirth { get; set; }
    }
}