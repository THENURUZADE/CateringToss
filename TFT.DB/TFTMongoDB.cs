using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TFT.Models.Models;

namespace TFT.DB
{
    public class TFTMongoDB<T>
    {
        public TFTMongoDB()
        {
            mongoClient = new MongoClient("mongodb://aran:airnav2012@localhost:27017");
            
            var database = mongoClient.GetDatabase("CateringToss");
            Type type = typeof(T);
            string a = type.Name;
            futureCollection = database.GetCollection<T>(a);
        }
        private static TFTMongoDB<T> client;
        private static object lockObject = new object();
       
        private MongoClient mongoClient;
        private IMongoCollection<T> futureCollection;
        public static TFTMongoDB<T> ClientAsSingleton()
        {
            lock (lockObject)
            {
                return client ?? (client = new TFTMongoDB<T>());
            }
        }
        public void InsertModel(T future)
        {
            futureCollection.InsertOne(future);
        }
        public List<T> Get()
        {
            var products = futureCollection.AsQueryable<T>().ToList();
            return products;
        }
        public bool Update(string id,T future)
        {
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();
            bool t = false;
            foreach (var property in propertyInfos)
            {
                if (property.Name != "Id")
                {
                    var x = property.GetValue(future);
                    string a = property.Name.ToLower();
                    var result = futureCollection.UpdateOne(
                    Builders<T>.Filter.Eq("_id", ObjectId.Parse(id)),
                    Builders<T>.Update.Set(a, property.GetValue(future)));
                    bool r  = false;
                    if (result.ModifiedCount > 0)
                    {
                        r = true;
                    }
                    if (r == true)
                    {
                        t = Convert.ToBoolean(result.ModifiedCount);
                    }
                }
            }
            return Convert.ToBoolean(t);
        }
        public bool Delete(string id)
        {
            var result = futureCollection.DeleteOne(
               Builders<T>.Filter.Eq("id", ObjectId.Parse(id)));
            return Convert.ToBoolean(result.DeletedCount);
        }
    }
}
