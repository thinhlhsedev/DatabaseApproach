using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repositories.Models
{
    public partial class ImportExport
    {
        public ImportExport()
        {
            ImportExportDetail = new HashSet<ImportExportDetail>();
        }

        public string ImportExportId { get; set; }
        public string AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ItemType { get; set; }
        public bool? IsImport { get; set; }
        public bool? IsAccepted { get; set; }

        public virtual Section Account { get; set; }
        public virtual ICollection<ImportExportDetail> ImportExportDetail { get; set; }
    }
}
