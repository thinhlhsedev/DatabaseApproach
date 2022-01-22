using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetail = new HashSet<OrderDetail>();
            ProductComponent = new HashSet<ProductComponent>();
        }

        [Key]
        [StringLength(100)]
        public string ProductId { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }
        public int? Amount { get; set; }
        public double? Price { get; set; }
        [StringLength(100)]
        public string ImageUrl { get; set; }
        [StringLength(100)]
        public string Unit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ManufacturingDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
        [StringLength(100)]
        public string Status { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductComponent> ProductComponent { get; set; }
    }
}
