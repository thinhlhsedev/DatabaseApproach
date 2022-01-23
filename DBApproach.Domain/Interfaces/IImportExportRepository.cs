using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Domain.Interfaces
{
    public interface IImportExportRepository : IRepository<ImportExport>
    {
        IQueryable<ImportExport> GetImportByAccount(Expression<Func<ImportExport, bool>> expression);

        IQueryable<ImportExport> GetExportByAccount(Expression<Func<ImportExport, bool>> expression);
    }
}
