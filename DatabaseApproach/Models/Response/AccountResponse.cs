using System;

namespace DatabaseApproach.Models.Response
{
    public class AccountResponse
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
    }
}
