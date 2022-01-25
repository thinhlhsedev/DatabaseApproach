using AutoMapper;
using DatabaseApproach.Models.Request;
using DatabaseApproach.Models.Response;
using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly ProcessService _processService;
        private readonly IMapper _mapper;

        public ProcessController(
             ProcessService processService,
             IMapper mapper)
        {
            _processService = processService;
            _mapper = mapper;
        }

        // GET: getAllProcesss
        [HttpGet]
        [Route("getAllProcesss")]
        public ActionResult<IQueryable<Process>> GetAllProcesss()
        {
            var data = _processService.GetAllProcesses();
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var list = _mapper.Map<IEnumerable<ProcessResponse>>(data);
            return Ok(list);
        }

        // GET: getProcess/1
        [HttpGet]
        [Route("getProcess/{processId}")]
        public ActionResult<ProcessResponse> GetProcessById(string processId)
        {
            var data = _processService.GetProcessById(processId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var process = _mapper.Map<ProcessResponse>(data);
            return Ok(process);
        }

        // PUT: UpdateProcess/1
        [HttpPut]
        [Route("updateProcess/{processId}")]
        public ActionResult<ProcessResponse> UpdateProcess(string processId, [FromBody] ProcessRequest newProcess)
        {
            var data = _processService.UpdateProcess(processId, _mapper.Map<Process>(newProcess));
            if (data == null)
            {
                return BadRequest("Update failed");
            }
            var process = _mapper.Map<ProcessResponse>(data);
            return Ok(process);
        }

        // PUT: DelProcess/1
        [HttpPut]
        [Route("delProcess/{processId}")]
        public ActionResult DelProcess(string processId)
        {
            var data = _processService.DelProcess(processId);
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
