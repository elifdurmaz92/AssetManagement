using AssetManagement.Core.Entity;
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
    public class AssetController : ControllerBase
    {
        public AssetController()
        {

        }

        [HttpPost("~/api/addasset")]
        public IActionResult Post([FromBody] Asset entity)
        {

        }
    }
}
