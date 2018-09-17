using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi_t2.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace webapi_t2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayersProcessor _context;

        public PlayersController(PlayersProcessor context) {
            _context = context;
        }
    
    [HttpGet]
    [Route("")] 
    public Task<Player[]> GetAll() {

        return _context.GetAll();
    }
    [HttpPost]
    [Route("")]
    public Task<Player> Create(NewPlayer newPlayer) {
        return _context.Create(newPlayer);
    }
    [HttpGet]
    [Route("{id}")]

    public Task<Player> Get(Guid id) {
        return _context.Get(id);
    }
    [HttpDelete]
    [Route("{id}")]

    public Task<Player> Delete(Guid id) {
        return _context.Delete(id);
    }
    [HttpPut]
    [Route("{id}")]
    public Task<Player> Modify(Guid id, ModifiedPlayer player) {

        return _context.Modify(id, player);
    }


    }
}