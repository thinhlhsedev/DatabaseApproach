using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Domain.Interfaces
{
    public interface IAttendanceDetailRepository : IRepository<AttendanceDetail>
    {
        IQueryable<AttendanceDetail> GetAttendanceDetailByAttendance(Expression<Func<AttendanceDetail, bool>> expression);
    }
}
