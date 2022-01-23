using DatabaseApproach.Domain.Repository.Models;
using DBApproach.Domain.Interfaces;
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

        public IQueryable<Component> GetAllComponents(Expression<Func<Component, bool>> expression)
        {
            return this.DbSet.Where(expression);
        }        
    }
}
