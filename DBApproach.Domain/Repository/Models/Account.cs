
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class Account
    {
        public Account()
        {
            AttendanceDetail = new HashSet<AttendanceDetail>();
            Order = new HashSet<Order>();
            Process = new HashSet<Process>();
        }

        /// <summary>
        /// This is ID belong to Account
        /// </summary>
        [Key]
        [StringLength(100)]
        public string AccountId { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public int? Gender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string AvatarUrl { get; set; }
        [StringLength(100)]
        public string RoleId { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(SectionDepartment.Account))]
        public virtual SectionDepartment AccountNavigation { get; set; }
        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Account")]
        public virtual Role Role { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<AttendanceDetail> AttendanceDetail { get; set; }
        [InverseProperty("Account")]
        public virtual ICollection<Order> Order { get; set; }
        [InverseProperty("Manufacturing")]
        public virtual ICollection<Process> Process { get; set; }
    }
}
