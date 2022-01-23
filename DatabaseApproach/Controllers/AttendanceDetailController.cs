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
    public class AttendanceDetailController : ControllerBase
    {
        private readonly AttendanceDetailService _attendanceDetailService;

        public AttendanceDetailController(
            AttendanceDetailService attendanceDetailService)
        {
            _attendanceDetailService = attendanceDetailService;
        }

        // GET: getAttendancesOf/atd/1
        [HttpGet]
        [Route("getAttendancesOf/atd/{attendanceId}")]
        public ActionResult<IQueryable<Attendance>> GetAttendanceDetailByAttendance(string attendanceId)
        {
            var data = _attendanceDetailService.GetAttendanceDetailByAttendance(attendanceId);
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
