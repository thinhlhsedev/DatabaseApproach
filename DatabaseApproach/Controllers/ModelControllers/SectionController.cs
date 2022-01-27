﻿using AutoMapper;
using DatabaseApproach.Models.Request;
using DatabaseApproach.Models.Response;
using DBApproach.Business.Services;
using DBApproach.Domain.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApproach.Controllers.ModelControllers
{
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly SectionService _sectionService;
        private readonly IMapper _mapper;

        public SectionController(
             SectionService sectionService,
             IMapper mapper)
        {
            _sectionService = sectionService;
            _mapper = mapper;
        }

        // GET: getWorkerAmounts/sec/1
        [HttpGet]
        [Route("getWorkerAmounts/sec/{accountId}")]
        public async Task<ActionResult<int>> GetWorkerAmountBySectionId(string accountId)
        {
            var data = await _sectionService.GetWorkerAmountBySectionId(accountId);            
            return Ok(data);
        }

        // GET: getSectionById/1
        [HttpGet]
        [Route("getSectionById/{accountId}")]
        public async Task<ActionResult<SectionResponse>> GetSectionById(string accountId)
        {
            var data = await _sectionService.GetSectionById(accountId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var section = _mapper.Map<SectionResponse>(data);
            return Ok(section);
        }

        // POST: AddSection/[section]
        [HttpPost]
        [Route("addSection")]
        public async Task<ActionResult> AddSection([FromBody] SectionRequest sectionRequest)
        {
            var data = await _sectionService.AddSection(_mapper.Map<Section>(sectionRequest));
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            return Ok("Add successfully");
        }

        // PUT: UpdateSection/1
        [HttpPut]
        [Route("updateSection/{accountId}")]
        public async Task<ActionResult> UpdateSection(string accountId, [FromBody] SectionRequest newSection)
        {
            var data = await _sectionService.UpdateSection(accountId, _mapper.Map<Section>(newSection));
            if (data.Equals(null))
            {
                return BadRequest("Not found");
            }
            else if (data.Equals("true"))
            {
                return Ok("Update Successfully");
            }
            return BadRequest(data);
        }

        // PUT: DelSection
        [HttpPut]
        [Route("delSection/{sectionId}")]
        public async Task<ActionResult> DelSection(string sectionId)
        {
            var data = await _sectionService.DelSection(sectionId);
            if (data.Equals(null))
            {
                return BadRequest("Not found");
            }
            else if (data.Equals("true"))
            {
                return Ok("Delete Successfully");
            }
            return BadRequest(data);
        }


        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
