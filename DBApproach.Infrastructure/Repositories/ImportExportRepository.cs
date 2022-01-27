using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DBApproach.Infrastructure.Repositories
{
    public class ImportExportRepository : Repository<ImportExport>, IImportExportRepository
    {
        public ImportExportRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }        
    }
}
