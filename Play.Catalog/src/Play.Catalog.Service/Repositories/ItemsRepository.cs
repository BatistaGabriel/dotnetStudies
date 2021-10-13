using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Play.Catalog.Entities;

namespace Play.Catalog.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private const string collectionName = "items"; // Represent a group of objects in mongoDB
        private readonly IMongoCollection<Item> dbCollection;
        private readonly FilterDefinitionBuilder<Item> filterDefinitionBuilder = Builders<Item>.Filter;

        public ItemsRepository(IMongoDatabase database)
        {
            dbCollection = database.GetCollection<Item>(collectionName);
        }

        public async Task<IReadOnlyCollection<Item>> GetAllAsync()
        {
            return await dbCollection.Find(filterDefinitionBuilder.Empty).ToListAsync();
        }

        public async Task<Item> GetAsync(Guid id)
        {
            FilterDefinition<Item> itemFilter = filterDefinitionBuilder.Eq(entity => entity.Id, id);
            return await dbCollection.Find(itemFilter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Item entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await dbCollection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(Item entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            FilterDefinition<Item> itemFilter = filterDefinitionBuilder.Eq(existingEntity => existingEntity.Id, entity.Id);
            await dbCollection.ReplaceOneAsync(itemFilter, entity);
        }

        public async Task RemoveAsync(Guid id)
        {
            FilterDefinition<Item> itemFilter = filterDefinitionBuilder.Eq(entity => entity.Id, id);
            await dbCollection.DeleteOneAsync(itemFilter);
        }
    }
}