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
    }
}
