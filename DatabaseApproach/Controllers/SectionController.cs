using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly SectionService _sectionService;

        public SectionController(
             SectionService sectionService)
        {
            _sectionService = sectionService;
        }

        // GET: getWorkerAmounts
        [HttpGet]
        [Route("getWorkerAmounts/{accountId}")]
        public ActionResult<int> GetWorkerAmountBySectionId(string accountId)
        {
            var data = _sectionService.GetWorkerAmountBySectionId(accountId);            
            return Ok(data);
        }

        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
