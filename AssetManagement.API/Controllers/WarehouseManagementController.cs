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
    public class WarehouseManagementController : ControllerBase
    {
        IWarehouseManagementDAL _dal;
        public WarehouseManagementController(IWarehouseManagementDAL dal)
        {
            _dal = dal;
        }

        [HttpGet]
        [Route("~/api/warehouseallassetlist/{Query}")]
        public async Task<IActionResult> GetAllWarehouseAssetListAsync(string Query)
        {
            var veri = await _dal.ExecuteSqlQueryOrProcedure(Query);
            return Ok(veri);

        }
    }
}
