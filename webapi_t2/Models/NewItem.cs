using System;
using System.ComponentModel.DataAnnotations;

namespace webapi_t2.Models
{
    public class NewItem
    {
        
        [Range(1,99)]
        public int Level { get; set; }
        [Required]
        public ItemType ItemType { get; set; }
        
        [DataType(DataType.Date)]
        [ValidateAttribute]
        public DateTime CreationTime { get; set; }
    }
    public enum ItemType
    {
        Weapon,
        Relic,
        HealthKit,
    }
}