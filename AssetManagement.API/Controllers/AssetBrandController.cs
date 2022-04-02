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
    public class AssetBrandController : ControllerBase
    {
        private readonly IAssetBrandDAL _dal;
        public AssetBrandController(IAssetBrandDAL dal)
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

        [HttpGet("~/api/getbrandbyassettype/{assetTypeID}")]
        public IActionResult GetAllBrandByAssetType(int assetTypeID)
        {
            try
            {
                var veri = _dal.GetAll(x => x.AssetTypeID == assetTypeID);

                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }

        }

        [HttpGet("~/api/getbrandbyid/{brandID}")]
        public IActionResult GetBrandByID(int brandID)
        {
            try
            {
                var veri = _dal.Get(x => x.ID == brandID);

                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }

        }

        [HttpPost]
        [Route("~/api/addassetbrand")]
        public IActionResult POST([FromBody] AssetBrand entity)
        {
            try
            {
                _dal.Add(entity);
                return new StatusCodeResult(201);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }   

        }

        [HttpPut]
        [Route("~/api/updateassetbrand")]
        public IActionResult PUT([FromBody] AssetBrand entity)
        {
            try
            {
                _dal.Update(entity);
                return new StatusCodeResult(200);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

        [HttpPut]
        [Route("~/api/deleteassetbrand")]
        public IActionResult DELETE([FromBody] AssetBrand entity)
        {
            try
            {
                _dal.SoftDelete(entity);
                return new StatusCodeResult(200);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }
    }
}
