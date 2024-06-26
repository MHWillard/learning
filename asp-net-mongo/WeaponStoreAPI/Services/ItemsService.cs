﻿//Service for CRUD operations.

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeaponStoreAPI.Models;

namespace WeaponStoreAPI.Services
{
    public class ItemsService
    {
        private readonly IMongoCollection<Item> _itemsCollection;

        //set up mongo client and database and initial collection.
        public ItemsService(IOptions<ItemStoreDatabaseSettings> itemStoreDatabaseSettings)
        {
            var mClient = new MongoClient(itemStoreDatabaseSettings.Value.ConnectionString);
            var mDatabase = mClient.GetDatabase(itemStoreDatabaseSettings.Value.DatabaseName);
            _itemsCollection = mDatabase.GetCollection<Item>(itemStoreDatabaseSettings.Value.ItemsCollectionName);
        }

        //CRUD operations.
        public async Task<List<Item>> GetAsync() =>
        await _itemsCollection.Find(_ => true).ToListAsync();

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
