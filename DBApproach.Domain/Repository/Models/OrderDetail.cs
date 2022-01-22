using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            Process = new HashSet<Process>();
        }

        [Key]
        [StringLength(100)]
        public string OrderDetailId { get; set; }
        [StringLength(100)]
        public string OrderId { get; set; }
        [StringLength(100)]
        public string ProductId { get; set; }
        public int? Amount { get; set; }
        public double? Price { get; set; }
        [StringLength(100)]
        public string Note { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderDetail")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderDetail")]
        public virtual Product Product { get; set; }
        [InverseProperty("OrderDetail")]
        public virtual ICollection<Process> Process { get; set; }
    }
}
