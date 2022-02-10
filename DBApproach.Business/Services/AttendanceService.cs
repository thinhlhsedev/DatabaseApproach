﻿using DBApproach.Domain.Repositories.Models;
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

        public async Task<Attendance> GetAttendanceById(int attendanceId)
        {
            return await _attendanceRepository.GetById(p => p.AttendanceId == attendanceId);            
        }

        public async Task<string> AddAttendance(Attendance attendance)
        {
            return await _attendanceRepository.Add(attendance);
        }

        public async Task<string> UpdateAttendance(int attendanceId, Attendance newAttendance)
        {

            var data = await _attendanceRepository.FindById(p => p.AttendanceId == attendanceId);
            if (data != null)
            {
                newAttendance.AttendanceId = data.AttendanceId;
                await _attendanceRepository.Update(newAttendance);               
            }
            return null;
        }

        public async Task<string> DelAttendance(int attendanceId)
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
