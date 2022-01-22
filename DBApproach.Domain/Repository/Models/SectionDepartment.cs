using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class SectionDepartment
    {
        public SectionDepartment()
        {
            Attendance = new HashSet<Attendance>();
            ImportExport = new HashSet<ImportExport>();
            Process = new HashSet<Process>();
        }

        [Key]
        [StringLength(100)]
        public string AccountId { get; set; }
        [StringLength(100)]
        public string ComponentId { get; set; }
        public int? WorkerAmount { get; set; }

        [ForeignKey(nameof(ComponentId))]
        [InverseProperty("SectionDepartment")]
        public virtual Component Component { get; set; }
        [InverseProperty("AccountNavigation")]
        public virtual Account Account { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<Attendance> Attendance { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<ImportExport> ImportExport { get; set; }
        [InverseProperty("Section")]
        public virtual ICollection<Process> Process { get; set; }
    }
}
