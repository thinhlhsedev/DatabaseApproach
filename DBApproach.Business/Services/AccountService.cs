using DatabaseApproach.Domain.Repository.Models;
using DBApproach.Domain.Interfaces;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(
            IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IQueryable<Account> GetAllAccounts()
        {
            IQueryable<Account> list = _accountRepository.GetAll(p => p.IsActive == true);
            return list;
        }
    }
}
