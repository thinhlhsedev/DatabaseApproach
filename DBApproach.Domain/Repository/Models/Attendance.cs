using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repository.Models
{
    public partial class Attendance
    {
        public Attendance()
        {
            AttendanceDetail = new HashSet<AttendanceDetail>();
        }

        public string AttendanceId { get; set; }
        public string AccountId { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? PresentedAmount { get; set; }
        public string Note { get; set; }

        public virtual Section Account { get; set; }
        public virtual ICollection<AttendanceDetail> AttendanceDetail { get; set; }
    }
}
