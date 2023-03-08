using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gokul.Models
{
    public class executive
    {

        [Key]
        public int ExecutiveId { get; set; }
        public string? ExecutiveName { get; set; }
        public int Age { get; set; }
        [ForeignKey("Order")]
        public int OrderTypeId { get; set; }
        public order? Order { get; set; }
        public int PhnNo { get; set; }

    }
}
