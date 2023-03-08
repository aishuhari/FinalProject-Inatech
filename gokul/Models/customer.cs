using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gokul.Models
{
    public class customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? FromAddress { get; set; }
        public string? ToAddress { get; set; }
        public string? City { get; set; }
        public int Weight { get; set; }

        [ForeignKey("Order")]
        public int OrderTypeId { get; set; }
        public order? Order { get; set; }
    }
}
