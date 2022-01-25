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

        public IQueryable<ImportExport> GetImExBySection(string accountId)
        {
            var data = _importExportRepository
                .GetImportByAccount(p => p.AccountId == accountId).Distinct();
            return data;
        }       

        public ImportExport GetImExtById(string imExId)
        {
            var data = _importExportRepository.GetById(p => p.ImportExportId == imExId);
            return data;
        }        

        public bool AddImEx(ImportExport imEx)
        {
            return false;
        }

        public ImportExport UpdateImEx(string imExId, ImportExport newImEx)
        {

            var data = _importExportRepository.GetById(p => p.ImportExportId == imExId);
            if (data != null)
            {
                newImEx.ImportExportId = data.ImportExportId;
                _importExportRepository.Update(newImEx);
                return newImEx;
            }
            return null;
        }

        public bool DelImEx(string imExId)
        {
            var data = _importExportRepository.GetById(p => p.ImportExportId == imExId);
            if (data != null)
            {
                data.IsAccepted = false;
                _importExportRepository.Update(data);
                return true;
            }
            return false;
        }
    }
}
