using DatabaseApproach.Domain.Repository.Models;
using DBApproach.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace DBApproach.Infrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }        
    }

}
