using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        [Key]
        [StringLength(100)]
        public string OrderId { get; set; }
        [StringLength(100)]
        public string AccountId { get; set; }
        public double? TotalPrice { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Deadline { get; set; }
        [StringLength(100)]
        public string Status { get; set; }
        [StringLength(100)]
        public string Note { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("Order")]
        public virtual Account Account { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
