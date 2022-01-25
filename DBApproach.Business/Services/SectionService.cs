using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class SectionService
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IAccountRepository _accountRepository;

        public SectionService(
            ISectionRepository sectionRepository,
            IAccountRepository accountRepository)
        {
            _sectionRepository = sectionRepository;
            _accountRepository = accountRepository;
            
        }

        public int GetWorkerAmountBySectionId(string sectionId)
        {
            var section = _sectionRepository.GetById(p => p.AccountId == sectionId);                       
            return (int)section.WorkerAmount;
        }

        public Section GetSectionById(string sectionId)
        {
            var data = _sectionRepository.GetById(p => p.AccountId == sectionId);
            return data;
        }

        public bool AddSection(Section section)
        {
            return false;
        }

        public Section UpdateSection(string sectionId, Section newSection)
        {

            var data = _sectionRepository.GetById(p => p.AccountId == sectionId);
            if (data != null)
            {
                newSection.AccountId = data.AccountId;
                _sectionRepository.Update(newSection);
                return newSection;
            }
            return null;
        }

        //public bool DelSection(string sectionId)
        //{
        //    var data = _sectionRepository.GetById(p => p.AccountId == sectionId);
        //    if (data != null)
        //    {
        //        var sec = _accountRepository.GetById(p => p.AccountId == sectionId);
        //        sec.IsActive = false;
        //        _accountRepository.Update(sec);                
        //        return true;
        //    }
        //    return false;
        //}
    }
}
