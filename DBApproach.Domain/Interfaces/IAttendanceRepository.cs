using DatabaseApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DBApproach.Domain.Interfaces
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        IQueryable<Attendance> GetAttendanceByAccount(string accountId);
    }
}
