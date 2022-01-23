using DatabaseApproach.Domain.Repository.Models;
using DBApproach.Domain.Interfaces;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class ComponentService
    {        
        private readonly IComponentRepository _componentRepository;

        public ComponentService(            
            IComponentRepository componentRepository)
        {            
            _componentRepository = componentRepository;
        }

        public IQueryable<Component> GetAllComponents()
        {            
            IQueryable<Component> list = _componentRepository.GetAll(p => p.Status == "1");
            return list;
        }
    }
}
