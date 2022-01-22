
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class Component
    {
        public Component()
        {
            ComponentMaterial = new HashSet<ComponentMaterial>();
            ImportExportDetail = new HashSet<ImportExportDetail>();
            ProductComponent = new HashSet<ProductComponent>();
            SectionDepartment = new HashSet<SectionDepartment>();
        }
        
        [Key]
        [StringLength(100)]
        public string ComponentId { get; set; }
        [StringLength(100)]
        public string ComponentName { get; set; }
        public int? Amount { get; set; }
        [StringLength(100)]
        public string ImageUrl { get; set; }
        public int? Unit { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ManufactuirngDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
        [StringLength(100)]
        public string Status { get; set; }

        [InverseProperty("Component")]
        public virtual ICollection<ComponentMaterial> ComponentMaterial { get; set; }
        [InverseProperty("Item")]
        public virtual ICollection<ImportExportDetail> ImportExportDetail { get; set; }
        [InverseProperty("Component")]
        public virtual ICollection<ProductComponent> ProductComponent { get; set; }
        [InverseProperty("Component")]
        public virtual ICollection<SectionDepartment> SectionDepartment { get; set; }
    }
}
