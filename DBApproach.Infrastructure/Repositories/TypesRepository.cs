using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBApproach.Infrastructure.Repositories
{
    public class TypesRepository : Repository<Types>, ITypesRepository
    {
        public TypesRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
