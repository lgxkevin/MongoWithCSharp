﻿using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoWithCsharp
{
    public class MongoCRUD
    {
        private IMongoDatabase db;

        public  MongoCRUD(string database)
        {
            // initial db client and connect to database
            var client = new MongoClient();
            db = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public List<T> LoadRecord<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("id", id);

            return collection.Find(filter).FirstOrDefault();
        }

        public List<T> LoadRecordByNumber<T>(string table, int startFrom, int count)
        {
            var collection = db.GetCollection<T>(table);

            var result = collection.Find(new BsonDocument()).Skip(startFrom).Limit(count).ToList();

            return result;
        }

        public void UpsertRecord<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);

            var result = collection.ReplaceOne(
                new BsonDocument("_id", id),
                record,
                new UpdateOptions { IsUpsert = true});

        }

        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("id", id);

            collection.DeleteOne(filter);
        }
    }
}