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

        // GET: getAccounts
        [HttpGet]
        [Route("getAccounts")]
        public ActionResult<IQueryable<Account>> GetAllAccounts()
        {
            var data = _accountService.GetAllAccounts();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
