using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DYLHS5_HFT_2021221.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public long PhoneNumber { get; set; }

        public string Address { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
