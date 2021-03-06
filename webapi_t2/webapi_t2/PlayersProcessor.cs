using System;
using System.Threading.Tasks;
using webapi_t2.Models;

namespace webapi_t2
{
    public class PlayersProcessor {
        
        private IRepository _Repository;

        public PlayersProcessor(IRepository Repository) {
            _Repository = Repository;

        }
        public async Task<Player[]> Top10() {
            return await _Repository.Top10();
        }
        public async Task<Player[]> GetX(int x) {
            return await _Repository.GetX(x);
        }
        public Task<Player> GetName(string name) {

        return _Repository.GetName(name);
    }
        public Task<Player[]> Common() {
            return _Repository.Common();
        }

        public async Task<Player> Create(NewPlayer player)
        {
            Player p1 = new Player();
            p1.Id = Guid.NewGuid();
            p1.Name = player.Name;
            p1.Score = player.Score;

            await _Repository.Create(p1);
            return p1;
        }
        public Task<Player> Delete(Guid id)
        {
            return _Repository.Delete(id);
        }
        public Task<Player> Get(Guid id)
        {
            return _Repository.Get(id);
        }
        public Task<Player[]> GetAll()
        {
            return _Repository.GetAll();
        }
        public async Task<Player> Modify(Guid id, ModifiedPlayer player)
        {
            Player p1 = new Player();
            p1.Id = id;
            p1.Score = player.Score;

            await _Repository.Modify(p1.Id, player);
            return p1;
        }
    }
}