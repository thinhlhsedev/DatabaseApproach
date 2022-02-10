﻿using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<int> GetWorkerAmountBySectionId(int sectionId)
        {
            var data = await _sectionRepository.GetById(p => p.SectionId == sectionId);
            return (int)data.WorkerAmount;
       }

        public async Task<Section> GetSectionById(int sectionId)
        {
            return await _sectionRepository.GetById(p => p.SectionId == sectionId);            
        }

        public async Task<string> AddSection(Section section)
        {
            return await _sectionRepository.Add(section);
        }

        public async Task<string> UpdateSection(int sectionId, Section newSection)
        {

            var data = await _sectionRepository.FindById(p => p.SectionId == sectionId);
            if (data != null)
            {
                newSection.SectionId = data.SectionId;
                await _sectionRepository.Update(newSection);                
            }
            return null;
        }

        public async Task<string> DelSection(int sectionId)
        {
            var data = await _sectionRepository.GetById(p => p.SectionId == sectionId);
            if (data != null)
            {                
                //data.Status = false;
                await _sectionRepository.Update(data);                
            }
            return null;
        }
    }
}
