using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
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

        public IQueryable<Role> AddCompoMate()
        {
            //List<Role> list = _componentMaterialRepository
            return null;
        }
    }
}
