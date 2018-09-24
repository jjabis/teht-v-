using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using webapi_t2.Models;

namespace webapi_t2
{
    public class MongoDbRepository : IRepository
    {
        private readonly IMongoCollection<Player> _collection;
        private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;

        public MongoDbRepository() {

            var mongoClient = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = mongoClient.GetDatabase("Game");
            _collection = database.GetCollection<Player>("players");
            _bsonDocumentCollection = database.GetCollection<BsonDocument>("players");
        }

        public async Task<Player> Create(Player player) {
            await _collection.InsertOneAsync(player);
            return player;
        }
        public async Task<Player[]> GetAll()
        {
            List<Player> players = await _collection.Find(new BsonDocument()).ToListAsync();
            return players.ToArray();
        }
        public Task<Player> Get(Guid id)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", id);
            return _collection.Find(filter).FirstAsync();
        }

        public async Task<Player> Delete(Guid id)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", id);
            Player p1 = await _collection.FindOneAndDeleteAsync(filter);
            return p1; 
        }
        public async Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", id);
            Player p1 = await _collection.Find(filter).FirstAsync();

            p1.Score = player.Score;

            await _collection.ReplaceOneAsync(filter, p1);
            return p1;
        }
        public async Task<Item> CreateItem(Guid id, Item item)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", id);
            Player p1 = await _collection.Find(filter).FirstAsync();

            p1.Items.Add(item);
            await _collection.ReplaceOneAsync(filter, p1);

            return item;
        }
        public async Task<Item> DeleteItem(Guid id, Guid itemId)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", id);
            Player p1 = await _collection.Find(filter).FirstAsync();
            
            Item i1 = p1.Items.Find(Item => Item.Id ==  itemId);
            p1.Items.Remove(i1);

            await _collection.ReplaceOneAsync(filter, p1);

            return i1;

        }
        public async Task<Item[]> GetAllItems(Guid id)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", id);
            Player p1 = await _collection.Find(filter).FirstAsync();

            int c = p1.Items.Count;
            Item[] il = new Item[c];
            for (int i = 0; i< c; i++) {
                il[i] = p1.Items[i];
            }
            await _collection.ReplaceOneAsync(filter, p1);

            return il;
        }

        public async Task<Item> GetItem(Guid id, Guid itemId)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", id);
            Player p1 = await _collection.Find(filter).FirstAsync();
            
            Item i1 = p1.Items.Find(item => item.Id ==  itemId);

            await _collection.ReplaceOneAsync(filter, p1);

            return i1;
        }  
        public async Task<Item> UpdateItem(Guid id, Guid itemId, ModifiedItem item)
        {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("_id", id);
            Player p1 = await _collection.Find(filter).FirstAsync();
            
            Item i1 = p1.Items.Find(Item => Item.Id == itemId);
            i1.Level = item.Level;

            await _collection.ReplaceOneAsync(filter, p1);

            return i1;
        }
    }
}