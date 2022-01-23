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

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class ImportExportController : ControllerBase
    {
        private readonly ImportExportService _importExportService;

        public ImportExportController(
            ImportExportService importExportService)
        {
            _importExportService = importExportService;
        }

        // GET: getImportsOf/acc/1
        [HttpGet]
        [Route("getImportsOf/acc/{accountId}")]
        public ActionResult<IQueryable<ImportExport>> GetImportBySection(string accountId)
        {
            var data = _importExportService.GetImportBySection(accountId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data); ;
        }

        // GET: getExportsOf/acc/1
        [HttpGet]
        [Route("getExportsOf/acc/{accountId}")]
        public ActionResult<IQueryable<Attendance>> GetExportBySection(string accountId)
        {
            var data = _importExportService.GetExportBySection(accountId);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data); ;
        }

        //private bool AttendanceExists(string id)
        //{
        //    return _context.Attendance.Any(e => e.AttendanceId == id);
        //}
    }
}
