using DBApproach.Domain.Repository.Models;
using DBApproach.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBApproach.Business.Services
{
    public class AttendanceDetailService
    {
        private readonly IAttendanceDetailRepository _attendanceDetailRepository;

        public AttendanceDetailService(
            IAttendanceDetailRepository attendanceDetailRepository)
        {
            _attendanceDetailRepository = attendanceDetailRepository;
        }

        public IQueryable<AttendanceDetail> GetAttendanceDetailByAttendance(string attendanceId)
        {
            IQueryable<AttendanceDetail> list = _attendanceDetailRepository
                .GetAttendanceDetailByAttendance(p => p.AttendanceId == attendanceId).Distinct();
            return list;
        }
    }
}
