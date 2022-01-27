using DBApproach.Domain.Repositories.Models;
using DBApproach.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<AttendanceDetail>> GetAttendanceDetailByAttendance(string attendanceId)
        {
            return await _attendanceDetailRepository
                .GetAttendanceDetailByAttendance(p => p.AttendanceId == attendanceId);            
        }

        public async Task<AttendanceDetail> GetAttendanceDetailById(string attendanceDetailId)
        {
            return await _attendanceDetailRepository.GetById(p => p.AttendanceDetailId == attendanceDetailId);            
        }

        public async Task<string> AddAttendanceDetail(AttendanceDetail attendanceDetail)
        {
            return await _attendanceDetailRepository.Add(attendanceDetail);
        }

        public async Task<string> UpdateAttendanceDetail(string attendanceDetailId, AttendanceDetail newAttendanceDetail)
        {

            var data = await _attendanceDetailRepository.FindById(p => p.AttendanceDetailId == attendanceDetailId);
            if (data != null)
            {
                newAttendanceDetail.AttendanceDetailId = data.AttendanceDetailId;
                await _attendanceDetailRepository.Update(newAttendanceDetail);                
            }
            return null;
        }

        public async Task<string> DelAttendanceDetail(string attendanceDetailId)
        {
            var data = await _attendanceDetailRepository.GetById(p => p.AttendanceDetailId == attendanceDetailId);
            if (data != null)
            {
                //data.Status = "Inactive";
                await _attendanceDetailRepository.Update(data);                
            }
            return null;
        }
    }
}
