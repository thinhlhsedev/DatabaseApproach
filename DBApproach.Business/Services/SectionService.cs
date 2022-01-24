using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class SectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(
            ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public int GetWorkerAmountBySectionId(string sectionId)
        {
            Section section = _sectionRepository.GetById(p => p.AccountId == sectionId);                       
            return (int)section.WorkerAmount;
        }
    }
}
