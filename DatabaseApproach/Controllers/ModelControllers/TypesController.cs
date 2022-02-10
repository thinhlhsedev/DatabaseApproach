using AutoMapper;
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
    public class TypesController : ControllerBase
    {
        private readonly TypesService _typesService;
        private readonly IMapper _mapper;

        public TypesController(
             TypesService typesService,
             IMapper mapper)
        {
            _typesService = typesService;
            _mapper = mapper;
        }

        // GET: getTypes/1
        

        // GET: getSectionById/1
        

        // POST: AddSection/[section]
        

        // PUT: UpdateSection/1
        

        // PUT: DelSection
        


        //private bool AccountExists(string id)
        //{
        //    return _context.Account.Any(e => e.AccountId == id);
        //}
    }
}
