using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class Role
    {
        public Role()
        {
            Account = new HashSet<Account>();
        }

        [Key]
        [StringLength(100)]
        public string RoleId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Status { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<Account> Account { get; set; }
    }
}
