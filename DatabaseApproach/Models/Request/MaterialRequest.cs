using DBApproach.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Request
{
    public class MaterialRequest
    {
        public string MaterialId { get; set; }
        public string MaterialName { get; set; }
        public int? Amount { get; set; }
        public string ImageUrl { get; set; }
        public int? Unit { get; set; }
        public string Status { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<ComponentMaterial> ComponentMaterial { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<ImportExportDetail> ImportExportDetail { get; set; }
    }
}
