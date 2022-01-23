using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly ProcessService _processService;

        public ProcessController(
             ProcessService processService)
        {
            _processService = processService;
        }

        // GET: getProcesses
        [HttpGet]
        [Route("getProcesses")]
        public ActionResult<IQueryable<Process>> GetAllProcesses()
        {
            var data = _processService.GetAllProcesses();
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
