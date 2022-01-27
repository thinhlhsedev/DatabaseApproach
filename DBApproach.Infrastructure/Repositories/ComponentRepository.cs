using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class ComponentRepository: Repository<Component>, IComponentRepository 
    {
        public ComponentRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }        
    }
}
