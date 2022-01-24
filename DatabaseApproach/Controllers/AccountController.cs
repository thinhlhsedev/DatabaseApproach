using DBApproach.Domain.Repository.Models;
using DBApproach.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;

        public AccountController(
            AccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: getAllAccounts
        [HttpGet]
        [Route("getAllAccounts")]
        public ActionResult<IQueryable<Account>> GetAllAccounts()
        {
            var data = _accountService.GetAllAccounts();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // GET: getAccountById
        [HttpGet]
        [Route("getAccountById/{accountId}")]
        public ActionResult<Account> GetAllAccountById(string accountId)
        {
            var data = _accountService.GetAccountById(accountId);
            if (data == null)
            {
                return NotFound("Not Found");
            }
            return Ok(data);
        }

        // DELETE: delAccount
        [HttpDelete]
        [Route("delAccounts/{accountId}")]
        public ActionResult<bool> DelAccounts(string accountId)
        {
            var data = _accountService.DelAccount(accountId);
            if (!data)
            {
                return NotFound("Delete Failed !");
            }
            return Ok("Delete Successfully !");
        }

        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
