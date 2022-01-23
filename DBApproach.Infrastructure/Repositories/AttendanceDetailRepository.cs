using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class AttendanceDetailRepository : Repository<AttendanceDetail>, IAttendanceDetailRepository
    {
        public AttendanceDetailRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<AttendanceDetail> GetAttendanceDetailByAttendance(Expression<Func<AttendanceDetail, bool>> expression)
        {
            return DbSet.Where(expression);
        }
    }
}
