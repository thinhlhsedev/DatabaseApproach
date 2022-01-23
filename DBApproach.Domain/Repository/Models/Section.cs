using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repository.Models
{
    public partial class Section
    {
        public Section()
        {
            Attendance = new HashSet<Attendance>();
            ImportExport = new HashSet<ImportExport>();
            Process = new HashSet<Process>();
        }

        public string AccountId { get; set; }
        public string ComponentId { get; set; }
        public int? WorkerAmount { get; set; }
        public bool? IsAssemble { get; set; }

        public virtual Account Account { get; set; }
        public virtual Component Component { get; set; }
        public virtual ICollection<Attendance> Attendance { get; set; }
        public virtual ICollection<ImportExport> ImportExport { get; set; }
        public virtual ICollection<Process> Process { get; set; }
    }
}
