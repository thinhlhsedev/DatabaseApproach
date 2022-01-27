﻿using DBApproach.Domain.Interfaces;
using DBApproach.Domain.Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<Material>> GetAllMaterials()
        {
            return await _materialRepository.GetAll(p => p.Status == "1");            
        }

        public async Task<Material> GetMaterialById(string materialId)
        {
            return await _materialRepository.GetById(p => p.MaterialId == materialId);            
        }

        public async Task<string> AddMaterial(Material material)
        {            
            return await _materialRepository.Add(material);
        }

        public async Task<string> UpdateMaterial(string materialId, Material newMaterial)
        {
            var data = await _materialRepository.FindById(p => p.MaterialId == materialId);
            if (data != null)
            {
                newMaterial.MaterialId = data.MaterialId;
                await _materialRepository.Update(newMaterial);                
            }
            return null;
        }

        public async Task<string> DelMaterial(string materialId)
        {
            var data = await _materialRepository.GetById(p => p.MaterialId == materialId);
            if (data != null)
            {
                data.Status = "Inactive";
                await _materialRepository.Update(data);                
            }
            return null;
        }
    }
}
