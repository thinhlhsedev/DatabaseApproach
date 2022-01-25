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
            var data = _materialRepository.GetAll(p => p.Status == "1").Distinct();
            return data;
        }

        public Material GetMaterialById(string materialId)
        {
            var data = _materialRepository.GetById(p => p.MaterialId == materialId);
            return data;
        }

        public bool AddMaterial(Material material)
        {            
            return false;
        }

        public Material UpdateMaterial(string materialId, Material newMaterial)
        {

            var data = _materialRepository.GetById(p => p.MaterialId == materialId);
            if (data != null)
            {
                newMaterial.MaterialId = data.MaterialId;
                _materialRepository.Update(newMaterial);
                return newMaterial;
            }
            return null;
        }

        public bool DelMaterial(string materialId)
        {
            var data = _materialRepository.GetById(p => p.MaterialId == materialId);
            if (data != null)
            {
                data.Status = "Inactive";
                _materialRepository.Update(data);
                return true;
            }
            return false;
        }
    }
}
