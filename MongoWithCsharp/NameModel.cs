using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoWithCsharp
{
    public class NameModel
    {
        [BsonId]
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}