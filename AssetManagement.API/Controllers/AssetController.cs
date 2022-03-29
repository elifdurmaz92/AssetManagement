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
        IAddNewAssetDAL _dal;
        public AssetController(IAddNewAssetDAL dal)
        {
            _dal = dal;
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
            }
            return BadRequest();
        }
    }
}
