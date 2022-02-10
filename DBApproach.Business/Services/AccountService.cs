﻿using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _accountRepository.GetAll(p => p.AccountId != 0);
        }

        public async Task<Account> GetAccountById(string accountId)
        {
            return await _accountRepository.GetById(p => p.AccountId == accountId);
        }

        public async Task<Account> GetAccountByEmail(string email)
        {
            return await _accountRepository.GetById(p => p.Email == email);
        }

        public async Task<string> AddAccount(Account account)
        {
            return await _accountRepository.Add(account);
        }

        public async Task<string> UpdateAccount(string accountId, Account newAccount)
        {
            var data = await _accountRepository.FindById(p => p.AccountId == accountId);
            if (data != null)
            {
                newAccount.AccountId = data.AccountId;
                await _accountRepository.Update(newAccount);
            }
            return null;
        }

        public async Task<string> DelAccount(string accountId)
        {
            var data = await _accountRepository.GetById(p => p.AccountId == accountId);
            if (data != null)
            {
                Account delAccount = data;
                delAccount.IsActive = false;
                await _accountRepository.Update(delAccount);
            }
            return null;
        }
    }
}
