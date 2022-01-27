using AutoMapper;
using DatabaseApproach.Models.Request;
using DBApproach.Business.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseApproach.Controllers.AuthControllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AccountService _accountService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public LoginController(
            AccountService accountService,
            IConfiguration configuration,
            IMapper mapper)
        {
            _accountService = accountService;
            _configuration = configuration;
            _mapper = mapper;
        }

        //// POST: login
        //[HttpPost]
        //[Route("login")]
        //public ActionResult Login([FromBody] AccountRequest accountRequest)
        //{
        //    var user = _accountService.GetAccountById(accountRequest.AccountId);

        //    //Generate Token
        //    var generateTokens = new TokenSignIn(_jwtSettings, _userManager);
        //    var signingCredentials = generateTokens.GetSigningCredential();
        //    var claims = generateTokens.GetClaim(user);
        //    var tokenOptions = generateTokens.GenerateTokenOptions(signingCredentials, await claims);
        //    var token = new JwtSecurityTokenHandler();
        //    token.WriteToken(tokenOptions);

        //    return Ok(_mapper.Map<UserReadDto>(user));
        //}
    }
}
