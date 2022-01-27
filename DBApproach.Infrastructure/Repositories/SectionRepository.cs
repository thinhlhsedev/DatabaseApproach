using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }        
    }
}
