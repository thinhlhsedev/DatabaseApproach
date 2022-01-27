using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBApproach.Business.Services
{
    public class ProcessService
    {
        private readonly IProcessRepository _processRepository;

        public ProcessService(
            IProcessRepository processRepository)
        {
            _processRepository = processRepository;
        }

        public async Task<List<Process>> GetAllProcesses()
        {
            return await _processRepository.GetAll(p => p.Status == "1");            
        }

        public async Task<Process> GetProcessById(string processId)
        {
            return await _processRepository.GetById(p => p.ProcessId == processId);            
        }

        public async Task<string> AddProcess(Process process)
        {
            return await _processRepository.Add(process);
        }

        public async Task<string> UpdateProcess(string processId, Process newProcess)
        {
            var data = await _processRepository.FindById(p => p.ProcessId == processId);
            if (data != null)
            {
                newProcess.ProcessId = data.ProcessId;
                await _processRepository.Update(newProcess);                
            }
            return null;
        }

        public async Task<string> DelProcess(string processId)
        {
            var data = await _processRepository.GetById(p => p.ProcessId == processId);
            if (data != null)
            {
                data.Status = "Inactive";
                await _processRepository.Update(data);                
            }
            return null;
        }
    }
}
