using DBApproach.Domain.Interfaces;
using System.ComponentModel;

namespace DBApproach.Infrastructure.Repositories
{
    public class ComponentRepository: Repository<Component>, IComponentRepository
    {
        public ComponentRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
