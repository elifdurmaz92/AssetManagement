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
    public class AssetActionController : ControllerBase
    {
        IAssetActionDAL _dal;
        public AssetActionController(IAssetActionDAL dal)
        {
            _dal = dal;
        }

        [HttpGet("~/api/getassetaction/{RegistrationNumber}")]
        public async Task<IActionResult> GetRegistrationNumberAssetAction(int registrationNumber)
        {
            try
            {
                var veri = await _dal.AssetActionDetailGET(registrationNumber);

                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }

        }


    }
}
