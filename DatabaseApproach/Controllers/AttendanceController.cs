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
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;
        private readonly IMapper _mapper;

        public AttendanceController(
            AttendanceService attendanceService,
            IMapper mapper)
        {
            _attendanceService = attendanceService;
            _mapper = mapper;
        }

        // GET: GetAttendancesOf/sec/1
        [HttpGet]
        [Route("getAttendancesOf/sec/{accountId}")]
        public ActionResult<IQueryable<AttendanceResponse>> GetAttendanceBySection(string accountId)
        {
            var data = _attendanceService.GetAttendanceBySection(accountId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var list = _mapper.Map<IEnumerable<AttendanceResponse>>(data);
            return Ok(list);
        }

        // GET: GetAttendance/1
        [HttpGet]
        [Route("getAttendance/{attendanceId}")]
        public ActionResult<AttendanceResponse> UpdateAttendance(string attendanceId)
        {
            var data = _attendanceService.GetAttendanceById(attendanceId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var attendance = _mapper.Map<AttendanceResponse>(data);
            return Ok(attendance);
        }

        // PUT: UpdateAttendance/1
        [HttpPut]
        [Route("updateAttendance/{attendanceId}")]
        public ActionResult<AttendanceResponse> UpdateAttendance(string attendanceId, [FromBody] AttendanceRequest newAttendance)
        {
            var data = _attendanceService.UpdateAttendance(attendanceId, _mapper.Map<Attendance>(newAttendance));
            if (data == null)
            {
                return BadRequest("Update failed");
            }
            var attendance = _mapper.Map<AttendanceResponse>(data);
            return Ok(attendance);
        }


        // PUT: DelAttendance/1
        [HttpPut]
        [Route("delAttendance/{attendanceId}")]
        public ActionResult DelAttendance(string attendanceId)
        {
            var data = _attendanceService.DelAttendance(attendanceId);
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
