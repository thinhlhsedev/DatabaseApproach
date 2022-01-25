using AutoMapper;
using DatabaseApproach.Models.Request;
using DatabaseApproach.Models.Response;
using DBApproach.Business.Services;
using DBApproach.Domain.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseApproach.Controllers
{
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly MaterialService _materialService;
        private readonly IMapper _mapper;

        public MaterialController(
             MaterialService materialService,
             IMapper mapper)
        {
            _materialService = materialService;
            _mapper = mapper;
        }

        // GET: getAllMaterials
        [HttpGet]
        [Route("getAllMaterials")]
        public ActionResult<IQueryable<Material>> GetAllMaterials()
        {
            var data = _materialService.GetAllMaterials();
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var list = _mapper.Map<IEnumerable<MaterialResponse>>(data);
            return Ok(list);
        }

        // GET: getMaterial/1
        [HttpGet]
        [Route("getMaterial/{materialId}")]
        public ActionResult<MaterialResponse> GetMaterialById(string materialId)
        {
            var data = _materialService.GetMaterialById(materialId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var material = _mapper.Map<MaterialResponse>(data);
            return Ok(material);
        }

        // PUT: UpdateMaterial/1
        [HttpPut]
        [Route("updateMaterial/{materialId}")]
        public ActionResult<MaterialResponse> UpdateMaterial(string materialId, [FromBody] MaterialRequest newMaterial)
        {
            var data = _materialService.UpdateMaterial(materialId, _mapper.Map<Material>(newMaterial));
            if (data == null)
            {
                return BadRequest("Update failed");
            }
            var material = _mapper.Map<MaterialResponse>(data);
            return Ok(material);
        }

        // PUT: DelMaterial/1
        [HttpPut]
        [Route("delMaterial/{materialId}")]
        public ActionResult DelMaterial(string materialId)
        {
            var data = _materialService.DelMaterial(materialId);
            if (!data)
            {
                return BadRequest("Delete Failed");
            }
            return Ok("Delete Successfully");
        }

        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
