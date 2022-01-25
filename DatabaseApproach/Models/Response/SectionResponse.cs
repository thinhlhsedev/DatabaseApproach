﻿using DBApproach.Domain.Repository.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Response
{
    public class SectionResponse
    {
        public string AccountId { get; set; }
        public string ComponentId { get; set; }
        public int? WorkerAmount { get; set; }
        public bool? IsAssemble { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Account Account { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Component Component { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Attendance> Attendance { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<ImportExport> ImportExport { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Process> Process { get; set; }
    }
}