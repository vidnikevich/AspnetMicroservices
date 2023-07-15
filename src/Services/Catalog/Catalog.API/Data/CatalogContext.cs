using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICantalogContext
    {
        public CatalogContext(IConfiguration configuration) 
        { 
            var client = new MongoClient(configuration.GetSection("DatabaseSettings").GetValue<string>("ConnectionString"));
            var database = client.GetDatabase(configuration.GetSection("DatabaseSettings").GetValue<string>("DatabaseName"));
            Products = database.GetCollection<Product>(configuration.GetSection("DatabaseSettings").GetValue<string>("ConnectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
