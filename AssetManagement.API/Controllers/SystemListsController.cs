using AssetManagement.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemListsController : ControllerBase
    {
        private readonly ISystemListsDAL _dal;
        public SystemListsController(ISystemListsDAL dal)
        {
            _dal = dal;

        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var veri = await _dal.GetAllAsync();

                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }

        }
    }
}
