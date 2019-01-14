using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SimpleBank.API.DomainModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.API.Controllers
{
    [Route("api/token")]
    [AllowAnonymous]
    public class TokenController : Controller
    {
        private IConfiguration configuration;

        public TokenController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpPost]
        public IActionResult RequestToken([FromForm] TokenRequestModel model)
        {
            //TODO: colocar no config file
            var secretkey = configuration["tokenSecretKey"];

            if (model.Username == "usermaster" && model.Password == "12345")
            {
                var claims = new[]
                {
                     new Claim("username", model.Username)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "indra.com.br",
                    audience: "indra.com.br",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Username e Password inválidos");
        }
    }
}
