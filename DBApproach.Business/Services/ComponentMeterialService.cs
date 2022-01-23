using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class ComponentMaterialService
    {
        private readonly IComponentMaterialRepository _componentMaterialRepository;

        public ComponentMaterialService(
            IComponentMaterialRepository componentMaterialRepository)
        {
            _componentMaterialRepository = componentMaterialRepository;
        }

        public IQueryable<Role> CreateCompoMate()
        {
            //IQueryable<Role> list = _componentMaterialRepository
            return null;
        }
    }
}
