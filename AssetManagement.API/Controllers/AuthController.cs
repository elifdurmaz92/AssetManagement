using AssetManagement.DAL;
using AssetManagement.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IAuthDAL _dal;
        public AuthController(IAuthDAL dal)
        {
            _dal = dal;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (!await _dal.RegisterAction(dto))
            {
                ModelState.AddModelError("error username notvalid", "zaten varsın");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();

            }
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var tokenValue = await _dal.LoginAction(dto);
                return Ok(tokenValue);
            }

        }
    }
}
