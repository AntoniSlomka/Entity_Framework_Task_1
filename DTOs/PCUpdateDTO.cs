using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstTask1.DTOs
{
    public class PCUpdateDTO
    {
        [MaxLength(50)]
        public string? Name { get; set; }

        [Range(0, 9999.9)]
        public float? Weight { get; set; }

        [Range(1, int.MaxValue)]
        public int? Warranty { get; set; }

        public DateTime? CreatedAt { get; set; }

        [Range(1, int.MaxValue)]
        public int? Stock { get; set; }
    }
}
