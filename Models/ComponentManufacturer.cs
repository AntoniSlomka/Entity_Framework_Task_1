using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstTask1.Models
{
    public class ComponentManufacturer
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Abbreviation { get; set; } = string.Empty;

        [MaxLength(300)]
        public string FullName { get; set; } = string.Empty;

        public DateTime FoundationDate { get; set; }

        public List<Component> Components { get; set; } = new();
    }
}
