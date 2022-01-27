using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;

namespace DBApproach.Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }

}
