using DBApproach.Domain.Repositories.Models;
using DBApproach.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<Attendance>> GetAttendanceBySection(string accountId)
        {
            return await _attendanceRepository
                .GetAttendanceBySection(p => p.AccountId == accountId);            
        }

        public async Task<Attendance> GetAttendanceById(string attendanceId)
        {
            return await _attendanceRepository.GetById(p => p.AttendanceId == attendanceId);            
        }

        public async Task<string> AddAttendance(Attendance attendance)
        {
            return await _attendanceRepository.Add(attendance);
        }

        public async Task<string> UpdateAttendance(string attendanceId, Attendance newAttendance)
        {

            var data = await _attendanceRepository.FindById(p => p.AttendanceId == attendanceId);
            if (data != null)
            {
                newAttendance.AttendanceId = data.AttendanceId;
                await _attendanceRepository.Update(newAttendance);               
            }
            return null;
        }

        public async Task<string> DelAttendance(string attendanceId)
        {
            var data = await _attendanceRepository.GetById(p => p.AttendanceId == attendanceId);
            if (data != null)
            {
                //data.Status = "Inactive";
                await _attendanceRepository.Update(data);                
            }
            return null;
        }
    }
}
