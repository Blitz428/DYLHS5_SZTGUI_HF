﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DYLHS5_HFT_2021221.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? OrderId { get; set; }

        public int? ProductId { get; set; }


        public int? CustomerId { get; set; }

        [Required]
        public bool? IsPrePaid { get; set; }

        [Required]
        public bool? IsTransportRequired { get; set; }

        private DateTime _ordertime;
        public virtual DateTime OrderTime { get { return _ordertime; } set { _ordertime = DateTime.Now; } }


        [NotMapped]
        public virtual Product Product { get; set; }
        [NotMapped]
        public virtual Customer Customer { get; set; }

        public override string ToString()
        {

            return "Order no: " + this.OrderId + "Order time: " + this.OrderTime;
        }

      

    }
}
