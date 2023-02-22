using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration confgiration)
        {
            var connString = confgiration.GetValue<string>("DatabaseSettings:ConnectionString");
            var client = new MongoClient(connString);
            var database = client.GetDatabase(connString);

            Products = database.GetCollection<Product>(connString);
            CatalogContextSeed.SeedData(Products);
        }
        public IMongoCollection<Product> Products { get;}
    }
}