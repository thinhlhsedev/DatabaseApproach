using DBApproach.Domain.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Response
{
    public class ImportExportResponse
    {
        public string ImportExportId { get; set; }
        public string AccountId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ItemType { get; set; }
        public bool? IsImport { get; set; }
        public bool? IsAccepted { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Section Account { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<ImportExportDetail> ImportExportDetail { get; set; }
    }
}
