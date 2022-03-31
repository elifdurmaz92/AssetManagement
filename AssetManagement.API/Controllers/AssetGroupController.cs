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
    public class AssetGroupController : ControllerBase
    {
        IAssetGroupDAL _dal;
        public AssetGroupController(IAssetGroupDAL dal)
        {
            _dal = dal;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var veri = await _dal.GetAllAsync();

            return Ok(veri);

        }

        [HttpGet("~/api/getgroupbyid/{groupID}")]
        public IActionResult GetGroupByID(int groupID)
        {
            try
            {
                var veri = _dal.Get(x => x.ID == groupID);

                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }

        }

        [HttpPost]
        [Route("~/api/addassetgroup")]
        public IActionResult POST([FromBody] AssetGroup entity)
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
        [Route("~/api/updateassetgroup")]
        public IActionResult PUT([FromBody] AssetGroup entity)
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
        [Route("~/api/deleteassetgroup")]
        public IActionResult DELETE([FromBody] AssetGroup entity)
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
