using DBApproach.Domain.Repository.Models;
using DBApproach.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using AutoMapper;
using DatabaseApproach.Models.Response;
using System.Collections.Generic;
using DatabaseApproach.Models.Request;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly AccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(
            AccountService accountService,
            IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        // GET: getAllAccounts
        [HttpGet]
        [Route("getAllAccounts")]
        public ActionResult<IQueryable<AccountResponse>> GetAllAccounts()
        {
            var data = _accountService.GetAllAccounts();            
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var list = _mapper.Map<IEnumerable<AccountResponse>>(data);
            return Ok(list);
        }

        // GET: GetAccount/1
        [HttpGet]
        [Route("getAccount/{accountId}")]
        public ActionResult<AccountResponse> GetAccountById(string accountId)
        {
            var data = _accountService.GetAccountById(accountId);
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            var account = _mapper.Map<AccountResponse>(data);
            return Ok(account);
        }

        // PUT: UpdateAccount
        [HttpPut]
        [Route("updateccount/{accountId}")]
        public ActionResult<AccountResponse> UpdateAccounts(string accountId, [FromBody]AccountRequest newAccount)
        {            
            var data = _accountService.UpdateAccount(accountId, _mapper.Map<Account>(newAccount));
            if (data == null)
            {
                return BadRequest("Update Failed !");
            }
            var account = _mapper.Map<AccountResponse>(data);
            return Ok(account);
        }

        // PUT: DelAccount
        [HttpPut]
        [Route("delAccount/{accountId}")]
        public ActionResult DelAccount(string accountId)
        {
            var data = _accountService.DelAccount(accountId);
            if (!data)
            {
                return BadRequest("Delete Failed !");
            }
            return Ok("Delete Successfully !");
        }

        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
