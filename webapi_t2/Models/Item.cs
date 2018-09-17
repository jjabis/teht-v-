using System;
using System.ComponentModel.DataAnnotations;

namespace webapi_t2.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        
        public int Level { get; set; }
        
        public ItemType ItemType { get; set; }
        
        public DateTime CreationTime { get; set; }
    }
    
}