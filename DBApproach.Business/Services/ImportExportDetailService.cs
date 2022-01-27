using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBApproach.Business.Services
{
    public class ImportExportDetailService
    {
        private readonly IImportExportDetailRepository _importExportDetailRepository;

        public ImportExportDetailService(
            IImportExportDetailRepository importExportDetailRepository)
        {
            _importExportDetailRepository = importExportDetailRepository;
        }

        public async Task<List<ImportExportDetail>> GetImExDetailByImEx(string imExId)
        {
            return await _importExportDetailRepository.GetAll(p => p.ImportExportId == imExId);            
        }

        public async Task<ImportExportDetail> GetImExDetailById(string imExDetailId)
        {
            return await _importExportDetailRepository.GetById(p => p.ImportExportDetailId == imExDetailId);            
        }

        public async Task<string> AddImExDetail(ImportExportDetail imExDetail)
        {
            return await _importExportDetailRepository.Add(imExDetail);
        }

        public async Task<string> UpdateImExDetail(string imExDetailId, ImportExportDetail newImExDetail)
        {
            var data = await _importExportDetailRepository.FindById(p => p.ImportExportDetailId == imExDetailId);
            if (data != null)
            {
                newImExDetail.ImportExportDetailId = data.ImportExportDetailId;
                await _importExportDetailRepository.Update(newImExDetail);                
            }
            return null;
        }

        public async Task<string> DelImExDetail(string imExDetailId)
        {
            var data = await _importExportDetailRepository.GetById(p => p.ImportExportDetailId == imExDetailId);
            if (data != null)
            {
                //data.Status = "Inactive";
                await _importExportDetailRepository.Update(data);                
            }
            return null;
        }
    }
}
