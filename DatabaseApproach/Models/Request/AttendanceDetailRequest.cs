using DBApproach.Domain.Repositories.Models;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Request
{
    public class AttendanceDetailRequest
    {
        public int AttendanceDetailId { get; set; }
        public int? AttendanceId { get; set; }
        public int? AccountId { get; set; }
        public bool? IsPresented { get; set; }
        public string Note { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Account Account { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Attendance Attendance { get; set; }
    }
}
