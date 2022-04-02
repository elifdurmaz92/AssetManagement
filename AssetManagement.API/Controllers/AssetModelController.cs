using AssetManagement.Core.Entity;
using AssetManagement.DAL;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IAssetModelDAL _dal;
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

        [HttpGet("~/api/getmodelbybrand/{assetBrandID}")]
        public IActionResult GetAllModelByBrand(int assetBrandID)
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

        [HttpGet("~/api/getmodelbyid/{modelID}")]
        public IActionResult GetBrandByID(int modelID)
        {
            try
            {
                var veri = _dal.Get(x => x.ID == modelID);

                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }

        }

        [HttpPost]
        [Route("~/api/addassetmodel")]
        public IActionResult POST([FromBody] AssetModel entity)
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
        [Route("~/api/updateassetmodel")]
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

        [HttpPut]
        [Route("~/api/deleteassetmodel")]
        public IActionResult DELETE([FromBody] AssetModel entity)
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
