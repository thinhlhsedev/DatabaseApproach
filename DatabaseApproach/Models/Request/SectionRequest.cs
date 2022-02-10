﻿using DBApproach.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Request
{
    public class SectionRequest
    {
        public int SectionId { get; set; }
        public int? SectionLeadId { get; set; }
        public string ComponentId { get; set; }
        public int? WorkerAmount { get; set; }
        public bool? IsAssemble { get; set; }
        public string InstructionFilePath { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Component Component { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Account SectionLead { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Account> Account { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Process> Process { get; set; }
    }
}
