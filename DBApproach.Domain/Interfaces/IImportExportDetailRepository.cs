using DBApproach.Domain.Repository.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DBApproach.Domain.Interfaces
{
    public interface IImportExportDetailRepository : IRepository<ImportExportDetail>
    {
        IQueryable<ImportExportDetail> GetDetailByImExId(Expression<Func<ImportExportDetail, bool>> expression);        
    }
}
