using DBApproach.Domain.Repository.Models;
using DBApproach.Domain.Interfaces;
using System.Linq;
using System;

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
            IQueryable<Account> list = _accountRepository.GetAll(p => p.AccountId != null);
            return list;
        }

        public Account GetAccountById(string accountId)
        {
            var data = _accountRepository.GetById(p => p.AccountId == accountId);
            return data;
        }

        public bool AddAccount()
        {
            return false;
        }

        public bool DelAccount(string accountId)
        {
            var data = _accountRepository.GetById(p => p.AccountId == accountId);
            if (data != null)
            {
                _accountRepository.Delete(data);
                return true;
            }
            return false;
        }
    }
}
