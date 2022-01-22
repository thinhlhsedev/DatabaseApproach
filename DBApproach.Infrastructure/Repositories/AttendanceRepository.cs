using DatabaseApproach.Domain.Repository.Models;
using DBApproach.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DBApproach.Infrastructure.Repositories
{
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        public AttendanceRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }        

        public IQueryable<Attendance> GetAttendanceByAccount(string accountId)
        {
            return DbSet.Where(p => p.AccountId == accountId);
        }        
    }
}
