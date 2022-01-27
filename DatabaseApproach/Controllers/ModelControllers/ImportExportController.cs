using AutoMapper;
using DatabaseApproach.Models.Request;
using DatabaseApproach.Models.Response;
using DBApproach.Business.Services;
using DBApproach.Domain.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApproach.Controllers.ModelControllers
{
    [ApiController]
    public class ImportExportController : ControllerBase
    {
        private readonly ImportExportService _importExportService;
        private readonly IMapper _mapper;

        public ImportExportController(
            ImportExportService importExportService,
            IMapper mapper)
        {
            _importExportService = importExportService;
            _mapper = mapper;
        }

        // GET: getImExsOf/sec/1
        [HttpGet]
        [Route("getImExsOf/sec/{accountId}")]
        public async Task<ActionResult<List<ImportExportResponse>>> GetImExBySection(string accountId)
        {
            var data = await _importExportService.GetImExBySection(accountId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var list = _mapper.Map<List<ImportExportResponse>>(data);
            return Ok(list);
        }

        // GET: getImEx/1
        [HttpGet]
        [Route("getImEx/{imExId}")]
        public async Task<ActionResult<ImportExportResponse>> GetImExById(string imExId)
        {
            var data = await _importExportService.GetImExtById(imExId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var imEx = _mapper.Map<ImportExportResponse>(data);
            return Ok(imEx);
        }

        // POST: AddImEx/[imEx]
        [HttpPost]
        [Route("addImEx")]
        public async Task<ActionResult> AddAccount([FromBody] ImportExportRequest importExportRequestRequest)
        {
            var data = await _importExportService.AddImEx(_mapper.Map<ImportExport>(importExportRequestRequest));
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            return Ok("Add successfully");
        }

        // PUT: UpdateImEx/1
        [HttpPut]
        [Route("updateImEx/{imExId}")]
        public async Task<ActionResult> UpdateImEx(string imExId, [FromBody] ImportExportRequest importExportRequest)
        {
            var data = await _importExportService.UpdateImEx(imExId, _mapper.Map<ImportExport>(importExportRequest));
            if (data.Equals(null))
            {
                return BadRequest("Not found");
            }
            else if (data.Equals("true"))
            {
                return Ok("Update Successfully");
            }
            return BadRequest(data);
        }

        // PUT: DelImEx/1
        [HttpPut]
        [Route("delImEx/{imExId}")]
        public async Task<ActionResult> DelImEx(string imExId)
        {
            var data = await _importExportService.DelImEx(imExId);
            if (data.Equals(null))
            {
                return BadRequest("Not found");
            }
            else if (data.Equals("true"))
            {
                return Ok("Update Successfully");
            }
            return BadRequest(data);
        }

        //private bool AttendanceExists(string id)
        //{
        //    return _context.Attendance.Any(e => e.AttendanceId == id);
        //}
    }
}
