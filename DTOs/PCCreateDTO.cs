using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstTask1.DTOs
{
    public class PCCreateDTO
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0, 9999.9)]
        public float Weight { get; set; }   

        [Required]
        [Range(1, int.MaxValue)]
        public int Warranty { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Stock { get; set; }
    }
}
