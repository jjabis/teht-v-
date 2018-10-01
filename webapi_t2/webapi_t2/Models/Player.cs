using System;
using System.Collections.Generic;

namespace webapi_t2.Models
{
    public class Player
    {
     
        public Player(){
            Items = new List<Item>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsBanned { get; set; }
        public DateTime CreationTime { get; set; }

        public List<Item> Items {get; set; }
        
    }
}