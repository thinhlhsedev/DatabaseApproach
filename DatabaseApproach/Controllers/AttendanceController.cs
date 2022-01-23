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
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;

        public AttendanceController(
            AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: getAttendancesOf/acc/1
        [HttpGet]
        [Route("getAttendancesOf/acc/{accountId}")]
        public ActionResult<IQueryable<Attendance>> GetAttendanceByAccount(string accountId)
        {
            var data = _attendanceService.GetAttendanceByAccount(accountId);
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
