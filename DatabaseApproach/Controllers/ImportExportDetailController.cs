using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class ImportExportDetailController : ControllerBase
    {
        private readonly ImportExportDetailService _importExportDetailService;

        public ImportExportDetailController(
            ImportExportDetailService importExportDetailService)
        {
            _importExportDetailService = importExportDetailService;
        }

        // GET: getDetailsOf/ImEx/1
        [HttpGet]
        [Route("getDetailsOf/ImEx/{imExId}")]
        public ActionResult<IQueryable<ImportExport>> GetDetailByImExId(string imExId)
        {
            var data = _importExportDetailService.GetDetailByImExId(imExId);
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
