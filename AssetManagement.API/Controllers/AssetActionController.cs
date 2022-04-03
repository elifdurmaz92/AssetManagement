using AssetManagement.Core.Entity;
using AssetManagement.DAL;
using AssetManagement.DTO.DTO;
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
       private readonly IAssetActionDAL _dal;
        private readonly IAssetStatusDAL _assetstatusDAL;
        public AssetActionController(IAssetActionDAL dal, IAssetStatusDAL assetstatusDAL)
        {
            _dal = dal;
            _assetstatusDAL = assetstatusDAL;
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


        [HttpPost]
        [Route("~/api/addassetaction")]
        public IActionResult AssetActionPOST([FromBody] AssetStatus entity)
        {
            try
            {
                _assetstatusDAL.Add(entity);
                return new StatusCodeResult(201);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }

        }



    }
}
