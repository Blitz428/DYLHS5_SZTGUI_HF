using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DYLHS5_HFT_2021221.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int Size { get; set; }

        public double? Price { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
        public Product()
        {
            Orders = new List<Order>();
        }
        public override string ToString()
        {
            return this.ProductName + " - " + this.Color + " - " + this.Size + " - " + this.Price;
        }
    }
}
