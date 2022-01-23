using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repository.Models;
using System.Linq;

namespace DBApproach.Business.Services
{
    public class MaterialService
    {
        private readonly IMaterialRepository _materialRepository;

        public MaterialService(
            IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public IQueryable<Material> GetAllMaterials()
        {
            IQueryable<Material> list = _materialRepository.GetAll(p => p.Status == "1");
            return list;
        }
    }
}
