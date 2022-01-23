using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repository.Models
{
    public partial class Process
    {
        public string ProcessId { get; set; }
        public string OrderDetailId { get; set; }
        public string SectionId { get; set; }
        public string ManufacturingId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? FinishedDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? Amount { get; set; }
        public int? FinishedAmount { get; set; }
        public string Status { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
        public virtual Section Section { get; set; }
    }
}
