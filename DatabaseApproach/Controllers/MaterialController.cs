using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly MaterialService _materialService;

        public MaterialController(
             MaterialService materialService)
        {
            _materialService = materialService;
        }

        // GET: getMaterials
        [HttpGet]
        [Route("getMaterials")]
        public ActionResult<IQueryable<Material>> GetAllMaterials()
        {
            var data = _materialService.GetAllMaterials();
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
