using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    [Table("Component_Material")]
    public partial class ComponentMaterial
    {
        [Key]
        [StringLength(100)]
        public string Id { get; set; }
        [StringLength(100)]
        public string ComponentId { get; set; }
        [StringLength(100)]
        public string MaterialId { get; set; }

        [ForeignKey(nameof(ComponentId))]
        [InverseProperty("ComponentMaterial")]
        public virtual Component Component { get; set; }
        [ForeignKey(nameof(MaterialId))]
        [InverseProperty(nameof(Matrial.ComponentMaterial))]
        public virtual Matrial Material { get; set; }
    }
}
