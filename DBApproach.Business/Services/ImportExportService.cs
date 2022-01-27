using DBApproach.Domain.Repositories.Models;
using DBApproach.Domain.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        public async Task<List<ImportExport>> GetImExBySection(string accountId)
        {
            return await _importExportRepository.GetAll(p => p.AccountId == accountId);
        }

        public async Task<ImportExport> GetImExtById(string imExId)
        {
            return await _importExportRepository.GetById(p => p.ImportExportId == imExId);
        }

        public async Task<string> AddImEx(ImportExport imEx)
        {
            return await _importExportRepository.Add(imEx);
        }

        public async Task<string> UpdateImEx(string imExId, ImportExport newImEx)
        {

            var data = await _importExportRepository.FindById(p => p.ImportExportId == imExId);
            if (data != null)
            {
                newImEx.ImportExportId = data.ImportExportId;
                await _importExportRepository.Update(newImEx);
            }
            return null;
        }

        public async Task<string> DelImEx(string imExId)
        {
            var data = await _importExportRepository.GetById(p => p.ImportExportId == imExId);
            if (data != null)
            {
                data.IsAccepted = false;
                await _importExportRepository.Update(data);
            }
            return null;
        }
    }
}
