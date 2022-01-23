using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class RoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(
            IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IQueryable<Role> GetAllRoles()
        {
            IQueryable<Role> list = _roleRepository.GetAll(p => p.Status == "1");
            return list;
        }
    }
}
