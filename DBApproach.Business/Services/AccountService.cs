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
            var data = _accountRepository.GetAll(p => p.AccountId != null).Distinct();            
            return data;
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

        public Account UpdateAccount(string accountId, Account newAccount)
        {
            var data = _accountRepository.FindById(p => p.AccountId == accountId);
            if (data != null)
            {
                newAccount.AccountId = data.AccountId;
                _accountRepository.Update(newAccount);
                return newAccount;
            }
            return null;
        }

        public bool DelAccount(string accountId)
        {
            var data = _accountRepository.GetById(p => p.AccountId == accountId);
            if (data != null)
            {
                data.IsActive = false;
                _accountRepository.Update(data);
                return true;
            }
            return false;
        }
    }
}
