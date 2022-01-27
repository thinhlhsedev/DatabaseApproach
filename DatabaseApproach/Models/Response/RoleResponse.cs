﻿using DBApproach.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DatabaseApproach.Models.Response
{
    public class RoleResponse
    {
        public string RoleId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual ICollection<Account> Account { get; set; }
    }
}
