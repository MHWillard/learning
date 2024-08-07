//Service for CRUD operations.

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using WeaponStoreAPI.Models;
using Microsoft.Extensions.Configuration;

namespace WeaponStoreAPI.Services
{
    public class ItemsService
    {
        private readonly IMongoCollection<Item> _itemsCollection;
        private IConfiguration _configuration;
        private readonly string? _key;

        //set up mongo client and database and initial collection.
        public ItemsService(IOptions<ItemStoreDatabaseSettings> itemStoreDatabaseSettings)
        {
            var mClient = new MongoClient(itemStoreDatabaseSettings.Value.ConnectionString);
            var mDatabase = mClient.GetDatabase("ItemsStore");

            /*
            List<string> databases = mClient.ListDatabaseNames().ToList();

            foreach (string database in databases)
            {
                Console.WriteLine(database);
            }
            */
            //string mongoConnect = Environment.GetEnvironmentVariable("MONGO_CONNECT");
        }

        //CRUD operations.
        //public async Task<List<Item>> GetAsync() =>
        //await _itemsCollection.Find(_ => true).ToListAsync();

        public async Task<List<Item>> GetAsync()
        {
            var itemsList = await _itemsCollection.Find(new BsonDocument()).ToListAsync();
            return itemsList;
        }

        //public async Task<Item?> GetAsync(string id) =>
        //await _itemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<Item?> GetAsync(string id) =>
        await _itemsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Item newItem) =>
        await _itemsCollection.InsertOneAsync(newItem);

        public async Task UpdateAsync(string id, Item updatedItem) =>
        await _itemsCollection.ReplaceOneAsync(x => x.Id == id, updatedItem);

        public async Task RemoveAsync(string id) =>
        await _itemsCollection.DeleteOneAsync(x => x.Id == id);
    }
}
