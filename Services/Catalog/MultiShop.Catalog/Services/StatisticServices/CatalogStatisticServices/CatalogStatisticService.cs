using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly IMongoCollection<Product> _productsCollection;
        private readonly IMongoCollection<Brand> _brandsCollection;
        private readonly IMongoCollection<Category> _categoriesCollection;

        public CatalogStatisticService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);

            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _productsCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);

            _brandsCollection = database.GetCollection<Brand>(databaseSettings.BrandCollectionName);

            _categoriesCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<string> GetMaxPriceProductsName()
        {
            // Önce en yüksek fiyatı al
            var maxPrice = await _productsCollection
                .Find(FilterDefinition<Product>.Empty)
                .SortByDescending(p => p.ProductPrice)
                .Limit(1)
                .Project(p => p.ProductPrice)
                .FirstOrDefaultAsync();

            if (maxPrice == default)
                return "No products found.";

            // Max fiyata sahip ürünleri getir
            var filter = Builders<Product>.Filter.Eq(p => p.ProductPrice, maxPrice);
            var names = await _productsCollection
                .Find(filter)
                .Project(p => p.ProductName)
                .ToListAsync();

            return names.Count > 0 ? string.Join(", ", names) : "No products found.";
        }

        public async Task<string> GetMinPriceProductsName()
        {
            // Önce minimum fiyatı al
            var minPrice = await _productsCollection
                .Find(FilterDefinition<Product>.Empty)
                .SortBy(p => p.ProductPrice)
                .Limit(1)
                .Project(p => p.ProductPrice)
                .FirstOrDefaultAsync();

            if (minPrice == default)
                return "No products found.";

            // Min fiyata sahip ürünleri getir
            var filter = Builders<Product>.Filter.Eq(p => p.ProductPrice, minPrice);
            var names = await _productsCollection
                .Find(filter)
                .Project(p => p.ProductName)
                .ToListAsync();

            return names.Count > 0 ? string.Join(", ", names) : "No products found.";
        }

        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var pipeline = new[]
            {
                // Önce geçerli fiyatları filtrele
                new BsonDocument("$match", new BsonDocument("ProductPrice", new BsonDocument("$gt", 0))),
                // Sonra ortalama hesapla  
                new BsonDocument("$group", new BsonDocument
                {
                    { "_id", BsonNull.Value },
                    { "avgPrice", new BsonDocument("$avg", "$ProductPrice") }
                })
            };

            var result = await _productsCollection.Aggregate<BsonDocument>(pipeline)
                .FirstOrDefaultAsync();

            return result?["avgPrice"]?.ToDecimal() ?? 0m;
        }

        public async Task<long> GetTotalBrandsAsync()
        {
            return await _brandsCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public async Task<long> GetTotalCategoriesAsync()
        {
            return await _categoriesCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<long> GetTotalProductsAsync()
        {
            return await _productsCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
