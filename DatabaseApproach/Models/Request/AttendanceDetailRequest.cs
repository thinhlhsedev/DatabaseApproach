using DBApproach.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Request
{
    public class AttendanceDetailRequest
    {
        public string AttendanceDetailId { get; set; }
        public string AttendanceId { get; set; }
        public string AccountId { get; set; }
        public int? IsPresented { get; set; }
        public string Note { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Account Account { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Attendance Attendance { get; set; }
    }
}
