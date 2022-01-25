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
using AutoMapper;
using DatabaseApproach.Models.Response;
using DatabaseApproach.Models.Request;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class AttendanceDetailController : ControllerBase
    {
        private readonly AttendanceDetailService _attendanceDetailService;
        private readonly IMapper _mapper;

        public AttendanceDetailController(
            AttendanceDetailService attendanceDetailService,
            IMapper mapper)
        {
            _attendanceDetailService = attendanceDetailService;
            _mapper = mapper;
        }

        // GET: getAttendancesOf/atd/1
        [HttpGet]
        [Route("getAttendancesOf/atd/{attendanceId}")]
        public ActionResult<IQueryable<AttendanceDetailResponse>> GetAttendanceDetailByAttendance(string attendanceId)
        {
            var data = _attendanceDetailService.GetAttendanceDetailByAttendance(attendanceId);
            if (data == null)
            {
                return NotFound();
            }
            var list = _mapper.Map<IEnumerable<AttendanceDetailResponse>>(data);
            return Ok(data); ;
        }

        // GET: getAttendanceDetail/1
        [HttpGet]
        [Route("getAttendanceDetail/{attendanceDetailId}")]
        public ActionResult<AttendanceDetailResponse> GetAttendanceDetailById(string attendanceDetailId)
        {
            var data = _attendanceDetailService.GetAttendanceDetailById(attendanceDetailId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var attendanceDetail = _mapper.Map<AttendanceDetailResponse>(data);
            return Ok(attendanceDetail);
        }

        // PUT: UpdateAttendanceDetail/1
        [HttpPut]
        [Route("updateAttendanceDetail/{attendanceDetailId}")]
        public ActionResult<AttendanceDetailResponse> UpdateAttendanceDetail(string attendanceDetailId, [FromBody] AttendanceDetailRequest newAttendanceDetail)
        {
            var data = _attendanceDetailService.UpdateAttendanceDetail(attendanceDetailId, _mapper.Map<AttendanceDetail>(newAttendanceDetail));
            if (data == null)
            {
                return BadRequest("Update failed");
            }
            var attendanceDetail = _mapper.Map<AttendanceDetailResponse>(data);
            return Ok(attendanceDetail);
        }

        // PUT: DelAttendanceDetail/1
        [HttpPut]
        [Route("delAttendanceDetail/{attendanceDetailId}")]
        public ActionResult DelAttendanceDetail(string attendanceDetailId)
        {
            var data = _attendanceDetailService.DelAttendanceDetail(attendanceDetailId);
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
