using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class Process
    {
        [Key]
        [StringLength(100)]
        public string ProcessId { get; set; }
        [StringLength(100)]
        public string OrderDetailId { get; set; }
        [StringLength(100)]
        public string SectionId { get; set; }
        [StringLength(100)]
        public string ManufacturingId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FinishedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ExpiryDate { get; set; }
        public int? Amount { get; set; }
        public int? FinishedAmount { get; set; }
        [StringLength(100)]
        public string Status { get; set; }

        [ForeignKey(nameof(ManufacturingId))]
        [InverseProperty(nameof(Account.Process))]
        public virtual Account Manufacturing { get; set; }
        [ForeignKey(nameof(OrderDetailId))]
        [InverseProperty("Process")]
        public virtual OrderDetail OrderDetail { get; set; }
        [ForeignKey(nameof(SectionId))]
        [InverseProperty(nameof(SectionDepartment.Process))]
        public virtual SectionDepartment Section { get; set; }
    }
}
