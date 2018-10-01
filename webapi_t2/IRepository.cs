using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using webapi_t2.Models;

namespace webapi_t2
{
    public interface IRepository
    {
        Task<Player[]> Top10();
        Task<Player[]> GetX(int x);
        Task<Player>GetName(string name);
        Task<BsonDocument> Common();
        Task<Player> Get(Guid id);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(Guid id, ModifiedPlayer player);
        Task<Player> Delete(Guid id);

        Task<Item> CreateItem(Guid playerId, Item item);
        Task<Item> GetItem(Guid playerId, Guid itemId);
        Task<Item[]> GetAllItems(Guid playerId);
        Task<Item> UpdateItem(Guid playerId, Guid itemId, ModifiedItem item);
        Task<Item> DeleteItem(Guid playerId, Guid itemId);
    }
}