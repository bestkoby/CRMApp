﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Antra.CRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServiceAsync _accountServiceAsync;
        private readonly IConfiguration _configuration;
        public AccountController(IAccountServiceAsync accountServiceAsync, IConfiguration configuration)
        {
            _accountServiceAsync = accountServiceAsync;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignupModel model)
        {
            var result = await _accountServiceAsync.SingUpAsync(model);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var res = await _accountServiceAsync.SignInAsync(model);
            if (!res.Succeeded)
            {
                return Unauthorized();
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, model.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken( 
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudiene"],
                expires: DateTime.Now.AddMinutes(20),
                claims:authClaims,  
                signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature) 
            );
            var h = new { jwt = new JwtSecurityTokenHandler().WriteToken(token) };
            return Ok(h); 
        }
    }
}
