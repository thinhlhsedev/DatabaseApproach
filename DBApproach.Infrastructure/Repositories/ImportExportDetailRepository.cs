using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Infrastructure.Repositories
{
    public class ImportExportDetailRepository : Repository<ImportExportDetail>, IImportExportDetailRepository
    {
        public ImportExportDetailRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<ImportExportDetail> GetDetailByImExId(Expression<Func<ImportExportDetail, bool>> expression)
        {
            return DbSet.Where(expression);
        }
    }
}
