using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DBApproach.Infrastructure.Repositories
{
    public class AttendanceDetailRepository : Repository<AttendanceDetail>, IAttendanceDetailRepository
    {
        public AttendanceDetailRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public async Task<List<AttendanceDetail>> GetAttendanceDetailByAttendance(Expression<Func<AttendanceDetail, bool>> expression)
        {
            return await DbSet.Where(expression).ToListAsync();
        }
    }
}
