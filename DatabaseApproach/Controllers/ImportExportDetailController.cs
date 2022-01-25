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
    public class ImportExportDetailController : ControllerBase
    {
        private readonly ImportExportDetailService _importExportDetailService;
        private readonly IMapper _mapper;

        public ImportExportDetailController(
            ImportExportDetailService importExportDetailService,
            IMapper mapper)
        {
            _importExportDetailService = importExportDetailService;
            _mapper = mapper;
        }

        // GET: getDetailsOf/ImEx/1
        [HttpGet]
        [Route("getDetailsOf/ImEx/{imExId}")]
        public ActionResult<IQueryable<ImportExportDetailResponse>> GetImExDetailByImEx(string imExId)
        {
            var data = _importExportDetailService.GetImExDetailByImEx(imExId);
            if (data == null)
            {
                return NotFound();
            }
            var list = _mapper.Map<IEnumerable<ImportExportDetailResponse>>(data);
            return Ok(data); ;
        }

        // GET: getImportExportDetail/1
        [HttpGet]
        [Route("getImportExportDetail/{imExDetailId}")]
        public ActionResult<ImportExportDetailResponse> GetImportExportDetailById(string imExDetailId)
        {
            var data = _importExportDetailService.GetImExDetailById(imExDetailId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var imExDetail = _mapper.Map<ImportExportDetailResponse>(data);
            return Ok(imExDetail);
        }

        // PUT: UpdateImportExportDetail/1
        [HttpPut]
        [Route("updateImportExportDetail/{imExDetailId}")]
        public ActionResult<ImportExportDetailResponse> UpdateImportExportDetail(string imExDetailId, [FromBody] ImportExportDetailRequest newImportExportDetail)
        {
            var data = _importExportDetailService.UpdateImExDetail(imExDetailId, _mapper.Map<ImportExportDetail>(newImportExportDetail));
            if (data == null)
            {
                return BadRequest("Update failed");
            }
            var imExDetail = _mapper.Map<ImportExportDetailResponse>(data);
            return Ok(imExDetail);
        }

        // PUT: DelImportExportDetail/1
        [HttpPut]
        [Route("delImportExportDetail/{imExDetailId}")]
        public ActionResult DelImportExportDetail(string imExDetailId)
        {
            var data = _importExportDetailService.DelImExDetail(imExDetailId);
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
