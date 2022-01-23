using DBApproach.Domain.Repository.Models;
using DBApproach.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class ComponentController : ControllerBase
    {

        private readonly ComponentService _componentService;

        public ComponentController(
             ComponentService componentService)
        {
            _componentService = componentService;
        }

        // GET: getComponents
        [HttpGet]
        [Route("getComponents")]
        public ActionResult<IQueryable<Account>> GetAllAccounts()
        {
            var data = _componentService.GetAllComponents();
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

