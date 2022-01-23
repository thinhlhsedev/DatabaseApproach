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

        public IQueryable<ImportExportDetail> GetDetailByImExId(string imExId)
        {
            IQueryable<ImportExportDetail> list = _importExportDetailRepository
                .GetDetailByImExId(p => p.ImportExportId == imExId);
            return list;
        }
    }
}
