using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repository.Models
{
    public partial class Account
    {
        public Account()
        {
            AttendanceDetail = new HashSet<AttendanceDetail>();
            Order = new HashSet<Order>();
        }

        public string AccountId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string AvatarUrl { get; set; }
        public string RoleId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Role Role { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<AttendanceDetail> AttendanceDetail { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
