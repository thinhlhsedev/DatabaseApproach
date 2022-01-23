using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(
             RoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: getRoles
        [HttpGet]
        [Route("getRoles")]
        public ActionResult<IQueryable<Role>> GetAllRoles()
        {
            var data = _roleService.GetAllRoles();
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
