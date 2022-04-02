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
    public class AssetManagementController : ControllerBase
    {
        private readonly IWarehouseManagementDAL _warehouseDAL;
        private readonly IPersonnelAssetDAL _perassetDAL;
        private readonly ITeamAssetDAL _teamassetDAL;
        public AssetManagementController(IWarehouseManagementDAL warehouseDAL, IPersonnelAssetDAL perassetDAL, ITeamAssetDAL teamassetDAL)
        {
            _warehouseDAL = warehouseDAL;
            _perassetDAL = perassetDAL;
            _teamassetDAL = teamassetDAL;
        }

        /// <summary>
        /// Depo Yönetimi Tüm varlıklar
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/warehouseallassetlist/{Query}")]
        public async Task<IActionResult> GetAllWarehouseAssetListAsync(string Query)
        {

            try
            {
                var veri = await _warehouseDAL.ExecuteSqlQueryOrProcedure(Query);
                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }         
        }

        /// <summary>
        /// Depo Yönetimi Personele atanan varlıklar
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/personnelassetlist/{Query}")]
        public async Task<IActionResult> GetAllPersonnelAssetListAsync(string Query)
        {
            try
            {
                var veri = await _perassetDAL.ExecuteSqlQueryOrProcedure(Query);
                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }

        }

        /// <summary>
        /// Depo yönetimi Takıma atanan varlıklar
        /// </summary>
        /// <param name="Query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("~/api/teamassetlist/{Query}")]
        public async Task<IActionResult> GetAllTeamAssetListAsync(string Query)
        {
            try
            {
                var veri = await _teamassetDAL.ExecuteSqlQueryOrProcedure(Query);
                return Ok(veri);
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }

        }
    }
}
