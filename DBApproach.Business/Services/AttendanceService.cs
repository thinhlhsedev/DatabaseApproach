using DBApproach.Domain.Repository.Models;
using DBApproach.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBApproach.Business.Services
{
    public class AttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceService(
            IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public IQueryable<Attendance> GetAttendanceByAccount(string accountId)
        {
            IQueryable<Attendance> list = _attendanceRepository
                .GetAttendanceByAccount(p => p.AccountId == accountId).Distinct();
            return list;
        }
    }
}
