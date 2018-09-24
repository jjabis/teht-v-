using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi_t2.Models;

namespace webapi_t2
{
    public class InMemoryRepository : IRepository
    {
        List<Player> PlayerList = new List<Player>();

        public Task<Player> Get(Guid id) {
            
            Player p1 = PlayerList.Find(Player => Player.Id == id);
            
            return Task.FromResult(p1);
        }   
        public Task<Player[]> GetAll() {
            int p = PlayerList.Count();
            Player[] pl = new Player[p];
            for (int i = 0; i< p; i++) {
                pl[i] = PlayerList[i];
            }
            return Task.FromResult(pl);
        }
        public Task<Player> Create(Player player) {

            PlayerList.Add(player);
            
            return Task.FromResult(player); 
        }
        public Task<Player> Modify(Guid id, ModifiedPlayer player) {
           
           Player p1 = PlayerList.Find(Player => Player.Id == id);
           p1.Score = player.Score;

            return Task.FromResult(p1);
        }
        public Task<Player> Delete(Guid id) {
            
            Player p1 = PlayerList.Find(Player => Player.Id == id);
            PlayerList.Remove(p1); 
            
            return Task.FromResult(p1);
        }
        public Task<Item> CreateItem(Guid id, Item item) {
            
            Player p1 = PlayerList.Find(Player => Player.Id == id);
            p1.Items.Add(item);

            

            return Task.FromResult(item);
        }
        public Task<Item> GetItem(Guid id, Guid ItemId) {
            Player p1 = PlayerList.Find(Player => Player.Id == id);
            Item i1 = p1.Items.Find(Item => Item.Id == ItemId);
            return Task.FromResult(i1);
        }
        public Task<Item[]> GetAllItems(Guid id) {
            Player p1 = PlayerList.Find(Player => Player.Id == id);
            int c = p1.Items.Count();
            Item[] il = new Item[c];
            for (int i = 0; i< c; i++) {
                il[i] = p1.Items[i];
            }
            return Task.FromResult(il);
        }
        public Task<Item> UpdateItem(Guid id, Guid itemId, ModifiedItem item) {

            Player p1 = PlayerList.Find(Player => Player.Id == id);
            Item i1 = p1.Items.Find(Item => Item.Id == itemId);

            i1.Level = item.Level;

            return Task.FromResult(i1);
        }
        public Task<Item> DeleteItem(Guid id, Guid itemId) {
            Player p1 = PlayerList.Find(Player => Player.Id == id);
            Item i1 = p1.Items.Find(Item => Item.Id == itemId);
            p1.Items.Remove(i1);
            return Task.FromResult(i1);
        }
    }
}