using System.ComponentModel.DataAnnotations;

namespace gokul.Models
{
    public class order
    {

        [Key]
        public int OrderTypeId { get; set; }

        public string? OrderType { get; set; }


    }
}
