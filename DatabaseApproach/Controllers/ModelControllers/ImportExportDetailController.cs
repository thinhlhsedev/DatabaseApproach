﻿using AutoMapper;
using DatabaseApproach.Models.Request;
using DatabaseApproach.Models.Response;
using DBApproach.Business.Services;
using DBApproach.Domain.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApproach.Controllers.ModelControllers
{
    [ApiController]
    public class ImportExportDetailController : ControllerBase
    {
        private readonly ImportExportDetailService _importExportDetailService;
        private readonly IMapper _mapper;

        public ImportExportDetailController(
            ImportExportDetailService importExportDetailService,
            IMapper mapper)
        {
            _importExportDetailService = importExportDetailService;
            _mapper = mapper;
        }

        // GET: getDetailsOf/ImEx/1
        [HttpGet]
        [Route("getDetailsOf/ImEx/{imExId}")]
        public async Task<ActionResult<List<ImportExportDetailResponse>>> GetImExDetailByImEx(string imExId)
        {
            var data = await _importExportDetailService.GetImExDetailByImEx(imExId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var list = _mapper.Map<List<ImportExportDetailResponse>>(data);
            return Ok(data); ;
        }

        // GET: getImportExportDetail/1
        [HttpGet]
        [Route("getImportExportDetail/{imExDetailId}")]
        public async Task<ActionResult<ImportExportDetailResponse>> GetImportExportDetailById(string imExDetailId)
        {
            var data = await _importExportDetailService.GetImExDetailById(imExDetailId);
            if (data == null)
            {
                return BadRequest("Not found");
            }
            var imExDetail = _mapper.Map<ImportExportDetailResponse>(data);
            return Ok(imExDetail);
        }

        // POST: AddImExDetail/[imExDetail]
        [HttpPost]
        [Route("addImExDetail")]
        public async Task<ActionResult> AddAImExDetail([FromBody] ImportExportDetailRequest importExportDetailRequest)
        {
            var data = await _importExportDetailService.AddImExDetail(_mapper.Map<ImportExportDetail>(importExportDetailRequest));
            if (data == null)
            {
                return BadRequest("Not Found");
            }
            return Ok("Add successfully");
        }

        // PUT: UpdateImportExportDetail/1
        [HttpPut]
        [Route("updateImportExportDetail/{imExDetailId}")]
        public async Task<ActionResult> UpdateImportExportDetail(string imExDetailId, [FromBody] ImportExportDetailRequest importExportDetailRequest)
        {
            var data = await _importExportDetailService.UpdateImExDetail(imExDetailId, _mapper.Map<ImportExportDetail>(importExportDetailRequest));
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

        // PUT: DelImportExportDetail/1
        [HttpPut]
        [Route("delImportExportDetail/{imExDetailId}")]
        public async Task<ActionResult> DelImportExportDetail(string imExDetailId)
        {
            var data = await _importExportDetailService.DelImExDetail(imExDetailId);
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

        //private bool AttendanceExists(string id)
        //{
        //    return _context.Attendance.Any(e => e.AttendanceId == id);
        //}
    }
}
