using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Domain.Interfaces
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        IQueryable<Attendance> GetAttendanceByAccount(Expression<Func<Attendance, bool>> expression);
    }
}
