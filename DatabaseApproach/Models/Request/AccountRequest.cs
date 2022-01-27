using DBApproach.Domain.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Request
{
    public class AccountRequest
    {
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


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Role Role { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Section Section { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<AttendanceDetail> AttendanceDetail { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Order> Order { get; set; }
    }    

}
