using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstTask1.Models
{
    public class PC
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(5)]
        public float Weight { get; set; }

        public int Warranty { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Stock { get; set; }

        public List<PCComponent> PCComponents { get; set; } = new();

    }
}
