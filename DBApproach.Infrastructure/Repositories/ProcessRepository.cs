using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;

namespace DBApproach.Infrastructure.Repositories
{
    public class ProcessRepository : Repository<Process>, IProcessRepository
    {
        public ProcessRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
