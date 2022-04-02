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
    public class PersonnelController : ControllerBase
    {
        IPersonnelDAL _dal;
        public PersonnelController(IPersonnelDAL dal)
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
        [Route("~/api/addPersonnel")]
        public IActionResult POST([FromBody] Personnel entity)
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
        [Route("~/api/updatePersonnel")]
        public IActionResult PUT([FromBody] Personnel entity)
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
