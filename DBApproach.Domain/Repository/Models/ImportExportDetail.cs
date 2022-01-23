using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DBApproach.Domain.Repository.Models
{
    public partial class ImportExportDetail
    {
        public string ImportExportDetailId { get; set; }
        public string ImportExportId { get; set; }
        public string ItemId { get; set; }
        public int? Amount { get; set; }

        public virtual ImportExport ImportExport { get; set; }
        public virtual Component Item { get; set; }
        public virtual Matrial ItemNavigation { get; set; }
    }
}
