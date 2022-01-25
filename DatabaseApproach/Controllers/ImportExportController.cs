using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DBApproach.Domain.Repository;
using DBApproach.Domain.Repository.Models;
using DBApproach.Business.Services;
using DatabaseApproach.Models.Response;
using AutoMapper;
using DatabaseApproach.Models.Request;

namespace DatabaseApproach.Controllers
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
        public ActionResult<IQueryable<ImportExport>> GetImportBySection(string accountId)
        {
            var data = _importExportService.GetImExBySection(accountId);
            if (data == null)
            {
                return NotFound();
            }
            var list = _mapper.Map<IEnumerable<ImportExportResponse>>(data);
            return Ok(list);
        }

        // GET: getImEx/1
        [HttpGet]
        [Route("getImEx/{imExId}")]
        public ActionResult<ImportExportResponse> GetImExById(string imExId)
        {
            var data = _importExportService.GetImExtById(imExId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var imEx = _mapper.Map<ImportExportResponse>(data);
            return Ok(imEx);
        }

        // PUT: UpdateImEx/1
        [HttpPut]
        [Route("updateImEx/{imExId}")]
        public ActionResult<ImportExportResponse> UpdateImEx(string imExId, [FromBody] ImportExportRequest newImEx)
        {
            var data = _importExportService.UpdateImEx(imExId, _mapper.Map<ImportExport>(newImEx));
            if (data == null)
            {
                return BadRequest("Update failed");
            }
            var imEx = _mapper.Map<ImportExportResponse>(data);
            return Ok(imEx);
        }

        // PUT: DelImEx/1
        [HttpPut]
        [Route("delImEx/{imExId}")]
        public ActionResult DelImEx(string imExId)
        {
            var data = _importExportService.DelImEx(imExId);
            if (!data)
            {
                return BadRequest("Delete Failed");
            }
            return Ok("Delete Successfully");
        }

        //private bool AttendanceExists(string id)
        //{
        //    return _context.Attendance.Any(e => e.AttendanceId == id);
        //}
    }
}
