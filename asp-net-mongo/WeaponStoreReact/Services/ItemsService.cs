//Service for CRUD operations.

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using WeaponStoreAPI.Models;

namespace WeaponStoreAPI.Services
{
    public class ItemsService
    {
        private readonly IMongoCollection<Item> _itemsCollection;

        //set up mongo client and database and initial collection.
        public ItemsService(IOptions<ItemStoreDatabaseSettings> itemStoreDatabaseSettings)
        {
            //var mClient = new MongoClient(itemStoreDatabaseSettings.Value.ConnectionString);
            //var mDatabase = mClient.GetDatabase(itemStoreDatabaseSettings.Value.DatabaseName);
            //_itemsCollection = mDatabase.GetCollection<Item>(itemStoreDatabaseSettings.Value.ItemsCollectionName);
            /*
                 "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "ItemStore",
    "ItemsCollectionName": "Items"
             
            var mClient = new MongoClient("mongodb://localhost:27017");
            var mDatabase = mClient.GetDatabase("ItemStore");
            _itemsCollection = mDatabase.GetCollection<Item>("Items");
            */
            var mClient = new MongoClient("mongodb+srv://warlord_user:xYxiz4ALjWFoYjdN@cluster0.k1mwy5p.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            //mongodb+srv://mhwillard:<password>@cluster0.k1mwy5p.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0
            var mDatabase = mClient.GetDatabase("ItemsStore");
            _itemsCollection = mDatabase.GetCollection<Item>("Items");

            List<string> databases = mClient.ListDatabaseNames().ToList();

            foreach (string database in databases)
            {
                Console.WriteLine(database);
            }
        }

        public ItemsService()
        {
            //var mClient = new MongoClient(itemStoreDatabaseSettings.Value.ConnectionString);
            //var mDatabase = mClient.GetDatabase(itemStoreDatabaseSettings.Value.DatabaseName);
            //_itemsCollection = mDatabase.GetCollection<Item>(itemStoreDatabaseSettings.Value.ItemsCollectionName);
            /*
                 "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "ItemStore",
    "ItemsCollectionName": "Items"

            var mClient = new MongoClient("mongodb://localhost:27017");
            var mDatabase = mClient.GetDatabase("ItemStore");
            _itemsCollection = mDatabase.GetCollection<Item>("Items");
            */
            var mClient = new MongoClient("mongodb+srv://warlord_user:xYxiz4ALjWFoYjdN@cluster0.k1mwy5p.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
            var mDatabase = mClient.GetDatabase("ItemsStore");
            _itemsCollection = mDatabase.GetCollection<Item>("Items");
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
