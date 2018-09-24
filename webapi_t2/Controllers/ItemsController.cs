using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi_t2.Models;

namespace webapi_t2.Controllers
{
    [Route("api/players/{id}/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemProcessor _context;

        public ItemsController(ItemProcessor context) {
            _context = context;
        }
    [HttpGet]
    [Route("")] 
    public Task<Item[]> GetAllItems(Guid id) {

        return _context.GetAllItems(id);
    }
    [HttpPost]
    [Route("")]
    public Task<Item> CreateItem(Guid id,NewItem newItem) {
        return _context.CreateItem(id, newItem);
    }
    [HttpGet]
    [Route("{itemId}")]
    public Task<Item> GetItem(Guid id, Guid itemId) {
        return _context.GetItem(id, itemId);
    }
    [HttpDelete]
    [Route("{itemId}")]
    public Task<Item> DeleteItem(Guid id, Guid itemId) {
        return _context.DeleteItem(id, itemId);
    }
    [HttpPut]
    [Route("{itemId}")]
    public Task<Item> UpdateItem(Guid id, Guid itemId, ModifiedItem item) {
        return _context.UpdateItem(id, itemId, item);
    }

}

}