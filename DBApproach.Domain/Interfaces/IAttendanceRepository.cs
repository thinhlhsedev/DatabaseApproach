﻿using DBApproach.Domain.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DBApproach.Domain.Interfaces
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        Task<List<Attendance>> GetAttendanceBySection(Expression<Func<Attendance, bool>> expression);
    }
}
