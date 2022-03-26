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
    public class UnitController : ControllerBase
    {
        IUnitDAL _dal;
        public UnitController(IUnitDAL dal)
        {
            _dal = dal;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            var veri = await _dal.GetAllAsync();

            return Ok(veri);

        }
        [HttpPost]
        [Route("~/api/addUnit")]
        public IActionResult POST([FromBody] Unit entity)
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
        [Route("~/api/updateUnit")]
        public IActionResult PUT([FromBody] Unit entity)
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
