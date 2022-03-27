using AssetManagement.Core.Entity;
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
    public class AssetModelController : ControllerBase
    {
        IAssetModelDAL _dal;
        public AssetModelController(IAssetModelDAL dal)
        {
            _dal = dal;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var veri = await _dal.GetAllAsync();

            return Ok(veri);

        }

        [HttpGet("~/api/getModelByBrand/{assetBrandID}")]
        public IActionResult GetAllBrandByAssetType(int assetBrandID)
        {
            try
            {
                var veri = _dal.GetAll(x => x.AssetBrandID == assetBrandID);

                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }

        }

        [HttpPost]
        [Route("~/api/addAssetModel")]
        public IActionResult POST([FromBody] AssetModel entity)
        {
            try
            {
                _dal.Add(entity);
                return new StatusCodeResult(201);
            }
            catch (Exception exc)
            {
            }
            return BadRequest();

        }

        [HttpPut]
        [Route("~/api/updateAssetModel")]
        public IActionResult PUT([FromBody] AssetModel entity)
        {
            try
            {
                _dal.Update(entity);
                return new StatusCodeResult(200);
            }
            catch (Exception)
            {
            }
            return BadRequest();

        }
    }
}
