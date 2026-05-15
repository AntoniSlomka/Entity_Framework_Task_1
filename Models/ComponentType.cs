using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstTask1.Models
{
    public class ComponentType
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Abbreviation { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        public List<Component> Components { get; set; } = new();
    }
}
