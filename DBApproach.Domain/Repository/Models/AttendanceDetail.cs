using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class AttendanceDetail
    {
        [Key]
        [StringLength(100)]
        public string AttendanceDetailId { get; set; }
        [StringLength(100)]
        public string AttendanceId { get; set; }
        [StringLength(100)]
        public string AccountId { get; set; }
        public int? IsPresented { get; set; }
        [StringLength(100)]
        public string Note { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty("AttendanceDetail")]
        public virtual Account Account { get; set; }
        [ForeignKey(nameof(AttendanceId))]
        [InverseProperty("AttendanceDetail")]
        public virtual Attendance Attendance { get; set; }
    }
}
