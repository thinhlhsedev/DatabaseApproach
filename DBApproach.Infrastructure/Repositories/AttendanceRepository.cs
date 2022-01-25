using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<Attendance> GetAttendanceBySection(Expression<Func<Attendance, bool>> expression)
        {
            return DbSet.Where(expression);
        }
    }
}
