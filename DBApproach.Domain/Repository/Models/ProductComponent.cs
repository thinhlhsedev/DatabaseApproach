using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    [Table("Product_Component")]
    public partial class ProductComponent
    {
        [Key]
        [StringLength(100)]
        public string Id { get; set; }
        [StringLength(100)]
        public string ProductId { get; set; }
        [StringLength(100)]
        public string ComponentId { get; set; }

        [ForeignKey(nameof(ComponentId))]
        [InverseProperty("ProductComponent")]
        public virtual Component Component { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductComponent")]
        public virtual Product Product { get; set; }
    }
}
