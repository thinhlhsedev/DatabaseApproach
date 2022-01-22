using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class Attendance
    {
        public Attendance()
        {
            AttendanceDetail = new HashSet<AttendanceDetail>();
        }

        [Key]
        [StringLength(100)]
        public string AttendanceId { get; set; }
        [StringLength(100)]
        public string AccountId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CheckDate { get; set; }
        public int? PresentedAmount { get; set; }
        [StringLength(100)]
        public string Note { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(SectionDepartment.Attendance))]
        public virtual SectionDepartment Account { get; set; }
        [InverseProperty("Attendance")]
        public virtual ICollection<AttendanceDetail> AttendanceDetail { get; set; }
    }
}
