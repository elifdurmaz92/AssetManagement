using AssetManagement.Core.Entity;
using AssetManagement.Data.Repository.AuthRepo;
using AssetManagement.DTO.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthRepo _repo;
        IConfiguration _conf;
        public AuthController(IAuthRepo repo,IConfiguration conf)
        {
            _repo = repo;
            _conf = conf;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (await _repo.UserExist(dto.UserName))
            {
                ModelState.AddModelError("error username notvalid", "zaten varsın");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            var username = new LoginInfo() { UserName = dto.UserName };

            await _repo.Register(username, dto.Password);

            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {

            var UserFound = await _repo.Login(dto.UserName, dto.Password);
            if (UserFound == null)
            {
                return null;
            }
            else
            {
                var key = Encoding.ASCII.GetBytes(_conf.GetSection("AppSettings:Token").Value);

                var description = new SecurityTokenDescriptor()
                {
                    Expires = DateTime.Now.AddDays(1),
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, UserFound.ID.ToString()),
                        new Claim(ClaimTypes.Name, UserFound.UserName)
        
                    }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)

                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(description);
                var tokenValue = tokenHandler.WriteToken(token);
                return Ok(tokenValue);
            }
        }
    }
}
