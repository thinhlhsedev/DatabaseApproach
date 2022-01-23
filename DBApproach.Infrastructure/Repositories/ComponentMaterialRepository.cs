using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class ComponentMaterialRepository : Repository<ComponentMaterial>, IComponentMaterialRepository
    {
        public ComponentMaterialRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
