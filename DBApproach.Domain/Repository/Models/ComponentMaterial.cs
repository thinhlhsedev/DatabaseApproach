using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repository.Models
{
    public partial class ComponentMaterial
    {
        public string Id { get; set; }
        public string ComponentId { get; set; }
        public string MaterialId { get; set; }

        public virtual Component Component { get; set; }
        public virtual Matrial Material { get; set; }
    }
}
