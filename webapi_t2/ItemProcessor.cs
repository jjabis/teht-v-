using System;
using System.Threading.Tasks;
using webapi_t2.Models;

namespace webapi_t2
{
    public class ItemProcessor
    {
        private IRepository _itemRepository;

        public ItemProcessor(IRepository itemRepository) {
            _itemRepository = itemRepository;

        }
        
        public Task<Item> CreateItem(Guid id, NewItem NewItem) {

            Player p1 = new Player();
            
            
            Item _item = new Item();
            _item.CreationTime = NewItem.CreationTime;
            _item.Id = Guid.NewGuid();
            _item.Level = NewItem.Level;
            _item.ItemType = NewItem.ItemType;

            if (_item.ItemType == 0 && p1.Score < 3) {
                throw new ItemException();
            }


            else {

            
            return _itemRepository.CreateItem(id, _item);
            
            }
        }
        public Task<Item[]> GetAllItems(Guid id){
            return _itemRepository.GetAllItems(id);
        }
        public Task<Item> GetItem(Guid id, Guid itemId) {
            return _itemRepository.GetItem(id, itemId);
        }
        public Task<Item> DeleteItem(Guid id, Guid itemId) {
            return _itemRepository.DeleteItem(id, itemId);
        }
        public Task<Item> UpdateItem(Guid id, Guid itemId, ModifiedItem item) {
            return _itemRepository.UpdateItem(id, itemId, item);
        }
    }
}