using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class ImportExportRepository : Repository<ImportExport>, IImportExportRepository
    {
        public ImportExportRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<ImportExport> GetExportByAccount(Expression<Func<ImportExport, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public IQueryable<ImportExport> GetImportByAccount(Expression<Func<ImportExport, bool>> expression)
        {
            return DbSet.Where(expression);
        }
    }
}
