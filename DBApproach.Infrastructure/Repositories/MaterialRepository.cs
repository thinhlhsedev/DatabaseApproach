using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;

namespace DBApproach.Infrastructure.Repositories
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }        
    }
}
