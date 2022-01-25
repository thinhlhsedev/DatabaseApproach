using System;

namespace DatabaseApproach.Models.Response
{
    public class AttendanceResponse
    {
        public string AttendanceId { get; set; }
        public string AccountId { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? PresentedAmount { get; set; }
        public string Note { get; set; }        
    }
}
