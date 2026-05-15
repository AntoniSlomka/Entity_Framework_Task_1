using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCodeFirstTask1.Models
{
    public class PCComponent
    {
        public int PCId { get; set; }
        public PC PC { get; set; }

        [MaxLength(10)]
        public string ComponentCode { get; set; }
        public Component Component { get; set; }

        public int Amount { get; set; }

    }
}
