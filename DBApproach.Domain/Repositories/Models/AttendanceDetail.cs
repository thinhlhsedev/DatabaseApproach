﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repositories.Models
{
    public partial class AttendanceDetail
    {
        public int AttendanceDetailId { get; set; }
        public int? AttendanceId { get; set; }
        public int? AccountId { get; set; }
        public bool? IsPresented { get; set; }
        public string Note { get; set; }

        public virtual Account Account { get; set; }
        public virtual Attendance Attendance { get; set; }
    }
}
