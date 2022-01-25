using DBApproach.Domain.Repository.Models;
using DBApproach.Domain.Interfaces;
using System.Linq;
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

        public IQueryable<ImportExportDetail> GetImExDetailByImEx(string imExId)
        {
            var data = _importExportDetailRepository
                .GetDetailByImExId(p => p.ImportExportId == imExId);
            return data;
        }

        public ImportExportDetail GetImExDetailById(string imExDetailId)
        {
            var data = _importExportDetailRepository.GetById(p => p.ImportExportDetailId == imExDetailId);
            return data;
        }

        public bool AddImExDetail(ImportExportDetail imExDetail)
        {
            return false;
        }

        public ImportExportDetail UpdateImExDetail(string imExDetailId, ImportExportDetail newImExDetail)
        {

            var data = _importExportDetailRepository.GetById(p => p.ImportExportDetailId == imExDetailId);
            if (data != null)
            {
                newImExDetail.ImportExportDetailId = data.ImportExportDetailId;
                _importExportDetailRepository.Update(newImExDetail);
                return newImExDetail;
            }
            return null;
        }

        public bool DelImExDetail(string imExDetailId)
        {
            var data = _importExportDetailRepository.GetById(p => p.ImportExportDetailId == imExDetailId);
            if (data != null)
            {
                //data.Status = "Inactive";
                _importExportDetailRepository.Update(data);
                return true;
            }
            return false;
        }
    }
}
