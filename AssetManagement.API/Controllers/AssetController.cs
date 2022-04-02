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
    public class AssetController : ControllerBase
    {
        private readonly IAddNewAssetDAL _dal;
        private readonly INewAssetDAL _newAssetDAL;
        public AssetController(IAddNewAssetDAL dal,INewAssetDAL newAssetDAL)
        {
            _dal = dal;
            _newAssetDAL = newAssetDAL;
        }

        [HttpPost("~/api/addasset")]
        public IActionResult Post([FromBody] AddNewAssetDTO asset)
        {
            try
            {
                _dal.AddNewAsset(asset);
                return new StatusCodeResult(201);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
            
        }

        [HttpGet("~/api/asset/newasset")]
        public async Task<IActionResult> NewAssetGet()
        {
            try
            {
                var veri =await _newAssetDAL.NewGetAsset();

                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }
    }
}
