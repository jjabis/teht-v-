using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi_t2.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Bson;

namespace webapi_t2.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [ExceptionFilter]
    public class PlayersController : ControllerBase
    {
        private readonly PlayersProcessor _context;

        public PlayersController(PlayersProcessor context) {
            _context = context;
        }
    [HttpGet]
    [Route("top10")] 
    public Task<Player[]> Top10() {

        return _context.Top10();
    }
    [HttpGet]
    [Route("minScore/{x}")] 
    public Task<Player[]> GetX(int x) {

        return _context.GetX(x);
    }
    [HttpGet]
    [Route("{name}")] 
    public Task<Player> GetName(string name) {

        return _context.GetName(name);
    }
    [HttpGet]
    [Route("common")]
    public Task<BsonDocument> Common() {
        return _context.Common();
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
    [Route("{id:guid}")]

    public Task<Player> Get(Guid id) {
        return _context.Get(id);
    }
    [HttpDelete]
    [Route("{id:guid}")]

    public Task<Player> Delete(Guid id) {
        return _context.Delete(id);
    }
    [HttpPut]
    [Route("{id:guid}")]
    public Task<Player> Modify(Guid id, ModifiedPlayer player) {

        return _context.Modify(id, player);
    }


    }
}