using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using webapi_t2.Models;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

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
        public async Task<Player[]> Top10() {
            List<Player> players = await _collection.Find(new BsonDocument()).ToListAsync();
            var sort = Builders<Player>.Sort.Descending("Score");
            int limit = 10;
            var cursor = _collection.Find(_=>true).Sort(sort).Limit(limit);
            players = await cursor.ToListAsync();
            return players.ToArray();

        }
        public async Task<Player[]> GetX(int x) {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Gte("Score", x);
            List<Player> plrs = await _collection.Find(filter).ToListAsync();

            return plrs.ToArray();
        }
        public async Task<Player> GetName(string name) {
            FilterDefinition<Player> filter = Builders<Player>.Filter.Eq("Name",name);
            return await _collection.Find(filter).FirstAsync();
        }
        public async Task<BsonDocument> Common() {
            var project = new BsonDocument{{"$project", new BsonDocument{{"Score", 1}}}};
            var group = new BsonDocument 
                { 
                    { "$group", 
                        new BsonDocument 
                            { 
                                { "_id", new BsonDocument 
                                             { 
                                                 { 
                                                     "Score","$Score" 
                                                 } 
                                             } 
                                }, 
                                { 
                                    "Count", new BsonDocument 
                                                 { 
                                                     { 
                                                         "$sum", 1 
                                                     } 
                                                 } 
                                }
                            }
                    }
                };
                                
                                
               var sort = new BsonDocument 
               {
                   { "$sort",
                    new BsonDocument 
                        {
                            {"Count", -1}
                        }
                    } 
                  
                
                };
            
            var pipeline = new[] { project, group, sort };
            
            var result = _collection.Aggregate<BsonDocument>(pipeline);

            return await result.FirstAsync();

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