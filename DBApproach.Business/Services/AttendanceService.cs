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

        public IQueryable<Attendance> GetAttendanceBySection(string accountId)
        {
            var data = _attendanceRepository
                .GetAttendanceBySection(p => p.AccountId == accountId).Distinct();
            return data;
        }

        public Attendance GetAttendanceById(string attendanceId)
        {
            var data = _attendanceRepository
                .GetById(p => p.AttendanceId == attendanceId);
            return data;
        }

        public bool AddAttendance()
        {
            return false;
        }

        public Attendance UpdateAttendance(string attendanceId, Attendance newAttendance)
        {

            var data = _attendanceRepository.GetById(p => p.AttendanceId == attendanceId);
            if (data != null)
            {
                newAttendance.AttendanceId = data.AttendanceId;
                _attendanceRepository.Update(newAttendance);
                return newAttendance;
            }
            return null;
        }

        public bool DelAttendance(string attendanceId)
        {
            var data = _attendanceRepository.GetById(p => p.AttendanceId == attendanceId);
            if (data != null)
            {
                //data.Status = "Inactive";
                _attendanceRepository.Update(data);
                return true;
            }
            return false;
        }
    }
}
