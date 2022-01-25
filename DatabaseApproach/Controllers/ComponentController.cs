using DBApproach.Domain.Repository.Models;
using DBApproach.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using DatabaseApproach.Models.Response;
using AutoMapper;
using DatabaseApproach.Models.Request;
using System.Collections.Generic;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class ComponentController : ControllerBase
    {

        private readonly ComponentService _componentService;
        private readonly IMapper _mapper;

        public ComponentController(
             ComponentService componentService,
             IMapper mapper)
        {
            _componentService = componentService;
            _mapper = mapper;
        }

        // GET: getAllComponents
        [HttpGet]
        [Route("getAllComponents")]
        public ActionResult<IQueryable<ComponentResponse>> GetAllAccounts()
        {
            var data = _componentService.GetAllComponents();
            if (data == null)
            {
                return NotFound();
            }
            var list = _mapper.Map<IEnumerable<ComponentResponse>>(data);
            return Ok(list);
        }

        // GET: getComponent/1
        [HttpGet]
        [Route("getComponent/{componentId}")]
        public ActionResult<ComponentResponse> GetComponentById(string componentId)
        {
            var data = _componentService.GetComponentById(componentId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var component = _mapper.Map<ComponentResponse>(data);
            return Ok(component);
        }

        // PUT: UpdateComponent/1
        [HttpPut]
        [Route("updateComponent/{componentId}")]
        public ActionResult<ComponentResponse> UpdateComponent(string componentId, [FromBody] ComponentRequest newComponent)
        {
            var data = _componentService.UpdateComponent(componentId, _mapper.Map<Component>(newComponent));
            if (data == null)
            {
                return BadRequest("Update failed");
            }
            var component = _mapper.Map<ComponentResponse>(data);
            return Ok(component);
        }

        // PUT: DelComponent/1
        [HttpPut]
        [Route("delComponent/{componentId}")]
        public ActionResult DelAttendance(string componentId)
        {
            var data = _componentService.DelComponent(componentId);
            if (!data)
            {
                return BadRequest("Delete Failed");
            }
            return Ok("Delete Successfully");
        }

        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}

