using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DatabaseApproach.Domain.Repository.Models
{
    public partial class ImportExportDetail
    {
        [Key]
        [StringLength(100)]
        public string ImportExportDetailId { get; set; }
        [StringLength(100)]
        public string ImportExportId { get; set; }
        [StringLength(100)]
        public string ItemId { get; set; }
        public int? Amount { get; set; }

        [ForeignKey(nameof(ImportExportId))]
        [InverseProperty("ImportExportDetail")]
        public virtual ImportExport ImportExport { get; set; }
        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Component.ImportExportDetail))]
        public virtual Component Item { get; set; }
        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Matrial.ImportExportDetail))]
        public virtual Matrial ItemNavigation { get; set; }
    }
}
