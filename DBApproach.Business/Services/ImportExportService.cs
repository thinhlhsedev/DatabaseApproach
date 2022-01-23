using DBApproach.Domain.Repository.Models;
using DBApproach.Domain.Interfaces;
using System.Linq;
namespace DBApproach.Business.Services
{
    public class ImportExportService
    {
        private readonly IImportExportRepository _importExportRepository;

        public ImportExportService(
            IImportExportRepository importExportRepository)
        {
            _importExportRepository = importExportRepository;
        }

        public IQueryable<ImportExport> GetImportBySection(string accountId)
        {
            IQueryable<ImportExport> list = _importExportRepository
                .GetImportByAccount(p => p.AccountId == accountId && p.IsImport == true);
            return list;
        }

        public IQueryable<ImportExport> GetExportBySection(string accountId)
        {
            IQueryable<ImportExport> list = _importExportRepository
                .GetExportByAccount(p => p.AccountId == accountId && p.IsImport == false);
            return list;
        }
    }
}
