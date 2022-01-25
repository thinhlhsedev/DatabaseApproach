using DBApproach.Domain.Repository.Models;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Request
{
    public class ImportExportDetailRequest
    {
        public string ImportExportDetailId { get; set; }
        public string ImportExportId { get; set; }
        public string ItemId { get; set; }
        public int? Amount { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ImportExport ImportExport { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Component Item { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Material ItemNavigation { get; set; }
    }
}
