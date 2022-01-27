using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
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
    }
}
