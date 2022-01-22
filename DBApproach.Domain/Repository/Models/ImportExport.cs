using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class ImportExport
    {
        public ImportExport()
        {
            ImportExportDetail = new HashSet<ImportExportDetail>();
        }

        [Key]
        [StringLength(100)]
        public string ImportExportId { get; set; }
        [StringLength(100)]
        public string AccountId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(100)]
        public string ItemType { get; set; }
        public bool? IsImport { get; set; }
        public bool? IsAccepted { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(SectionDepartment.ImportExport))]
        public virtual SectionDepartment Account { get; set; }
        [InverseProperty("ImportExport")]
        public virtual ICollection<ImportExportDetail> ImportExportDetail { get; set; }
    }
}
