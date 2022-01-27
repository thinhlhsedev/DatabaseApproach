using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repositories.Models
{
    public partial class AttendanceDetail
    {
        public string AttendanceDetailId { get; set; }
        public string AttendanceId { get; set; }
        public string AccountId { get; set; }
        public int? IsPresented { get; set; }
        public string Note { get; set; }

        public virtual Account Account { get; set; }
        public virtual Attendance Attendance { get; set; }
    }
}
