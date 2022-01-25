using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System.Linq;

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

        public IQueryable<Process> GetAllProcesses()
        {
            IQueryable<Process> list = _processRepository.GetAll(p => p.Status == "1");
            return list;
        }

        public Process GetProcessById(string processId)
        {
            var data = _processRepository.GetById(p => p.ProcessId == processId);
            return data;
        }

        public bool AddProcess(Process process)
        {
            return false;
        }

        public Process UpdateProcess(string processId, Process newProcess)
        {

            var data = _processRepository.GetById(p => p.ProcessId == processId);
            if (data != null)
            {
                newProcess.ProcessId = data.ProcessId;
                _processRepository.Update(newProcess);
                return newProcess;
            }
            return null;
        }

        public bool DelProcess(string processId)
        {
            var data = _processRepository.GetById(p => p.ProcessId == processId);
            if (data != null)
            {
                data.Status = "Inactive";
                _processRepository.Update(data);
                return true;
            }
            return false;
        }
    }
}
