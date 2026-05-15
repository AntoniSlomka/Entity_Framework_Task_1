using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstTask1.Models
{
    public class Component
    {
        [Key]
        [MaxLength(10)]
        public string Code { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;

        public List<PCComponent> PCComponents { get; set; } = new();

        public int ComponentManufacturerId { get; set; }
        public ComponentManufacturer ComponentManufacturer { get; set; }

        public int ComponentTypeId { get; set; }
        public ComponentType ComponentType { get; set; }

    }
}
