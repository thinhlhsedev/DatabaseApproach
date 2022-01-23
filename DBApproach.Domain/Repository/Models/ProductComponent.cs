﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repository.Models
{
    public partial class ProductComponent
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ComponentId { get; set; }

        public virtual Component Component { get; set; }
        public virtual Product Product { get; set; }
    }
}
