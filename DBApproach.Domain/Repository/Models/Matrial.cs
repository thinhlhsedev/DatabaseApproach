using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class Matrial
    {
        public Matrial()
        {
            ComponentMaterial = new HashSet<ComponentMaterial>();
            ImportExportDetail = new HashSet<ImportExportDetail>();
        }

        [Key]
        [StringLength(100)]
        public string MaterialId { get; set; }
        [StringLength(100)]
        public string MaterialName { get; set; }
        public int? Amount { get; set; }
        [StringLength(100)]
        public string ImageUrl { get; set; }
        public int? Unit { get; set; }
        [StringLength(100)]
        public string Status { get; set; }

        [InverseProperty("Material")]
        public virtual ICollection<ComponentMaterial> ComponentMaterial { get; set; }
        [InverseProperty("ItemNavigation")]
        public virtual ICollection<ImportExportDetail> ImportExportDetail { get; set; }
    }
}
