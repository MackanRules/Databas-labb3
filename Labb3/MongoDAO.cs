using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace Labb3
{
    internal class MongoDAO : IProductDAO
    {
        MongoClient dbClient;
        IMongoDatabase database;
        IMongoCollection<ProductODM> collection;
        public MongoDAO(string connectionString, string database)
        {
            this.dbClient = new MongoClient(connectionString);
            this.database = this.dbClient.GetDatabase(database);
            this.collection = this.database.GetCollection<ProductODM>("Products");
        }

        public void CreateProduct(ProductODM product)
        {
            try
            {
                this.collection.InsertOne(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            
        }

        public void DeleteProduct(string name)
        {
            var deleteFilter = Builders<ProductODM>.Filter.Eq("name", name);

            try
            {
                collection.DeleteOne(deleteFilter);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }

        }

        public List<ProductODM> GetAllProducts()
        {
            try
            {
                return this.collection.Find(new BsonDocument()).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
                return new List<ProductODM>();
            }
            
        }

        public void UpdateProduct(string name, int amount)
        {
            var filter = Builders<ProductODM>.Filter.Eq("name", name);
            var update = Builders<ProductODM>.Update.Set("amount", amount);

            try
            {
                collection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: " + ex.Message);
            }
            
        }
    }
}
