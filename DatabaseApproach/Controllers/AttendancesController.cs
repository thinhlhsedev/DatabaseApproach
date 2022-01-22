using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseApproach.Domain.Repository;
using DatabaseApproach.Domain.Repository.Models;
using DBApproach.Business.Services;

namespace DatabaseApproach.Controllers
{    
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;

        public AttendancesController(
            AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        // GET: getAttendancesOf/1
        [HttpGet]
        [Route("getAttendancesOf/{id}")]
        public ActionResult<IQueryable<Attendance>> GetAttendanceByAccount(string id)
        {
            var data = _attendanceService.GetAttendanceByAccount(id);
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
