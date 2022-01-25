using DBApproach.Domain.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Request
{
    public class AttendanceRequest
    {
        public string AttendanceId { get; set; }
        public string AccountId { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? PresentedAmount { get; set; }
        public string Note { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Section Account { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<AttendanceDetail> AttendanceDetail { get; set; }
    }
}
