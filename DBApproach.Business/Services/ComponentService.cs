using DBApproach.Domain.Repository.Models;
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
            var data = _componentRepository.GetAll(p => p.Status == "1").Distinct();
            return data;
        }

        public Component GetComponentById(string componentId)
        {
            var data = _componentRepository.GetById(p => p.ComponentId == componentId);
            return data;
        }

        public bool AddMaterial(Material material)
        {
            return false;
        }

        public Component UpdateComponent(string componentId, Component newComponent)
        {

            var data = _componentRepository.GetById(p => p.ComponentId == componentId);
            if (data != null)
            {
                newComponent.ComponentId = data.ComponentId;
                _componentRepository.Update(newComponent);
                return newComponent;
            }
            return null;
        }

        public bool DelComponent(string componentId)
        {
            var data = _componentRepository.GetById(p => p.ComponentId == componentId);
            if (data != null)
            {
                data.Status = "Inactive";
                _componentRepository.Update(data);
                return true;
            }
            return false;
        }
    }
}
