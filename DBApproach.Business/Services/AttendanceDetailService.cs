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
            var data = _attendanceDetailRepository
                .GetAttendanceDetailByAttendance(p => p.AttendanceId == attendanceId).Distinct();
            return data;
        }

        public AttendanceDetail GetAttendanceDetailById(string attendanceDetailId)
        {
            var data = _attendanceDetailRepository.GetById(p => p.AttendanceDetailId == attendanceDetailId);
            return data;
        }

        public bool AddAttendanceDetail(AttendanceDetail attendanceDetail)
        {
            return false;
        }

        public AttendanceDetail UpdateAttendanceDetail(string attendanceDetailId, AttendanceDetail newAttendanceDetail)
        {

            var data = _attendanceDetailRepository.GetById(p => p.AttendanceDetailId == attendanceDetailId);
            if (data != null)
            {
                newAttendanceDetail.AttendanceDetailId = data.AttendanceDetailId;
                _attendanceDetailRepository.Update(newAttendanceDetail);
                return newAttendanceDetail;
            }
            return null;
        }

        public bool DelAttendanceDetail(string attendanceDetailId)
        {
            var data = _attendanceDetailRepository.GetById(p => p.AttendanceDetailId == attendanceDetailId);
            if (data != null)
            {
                //data.Status = "Inactive";
                _attendanceDetailRepository.Update(data);
                return true;
            }
            return false;
        }
    }
}
