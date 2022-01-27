using DBApproach.Domain.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Response
{
    public class ComponentResponse
    {
        public string ComponentId { get; set; }
        public string ComponentName { get; set; }
        public int? Amount { get; set; }
        public string ImageUrl { get; set; }
        public int? Unit { get; set; }
        public DateTime? ManufactuirngDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Status { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<ComponentMaterial> ComponentMaterial { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<ImportExportDetail> ImportExportDetail { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<ProductComponent> ProductComponent { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Section> Section { get; set; }
    }
}
