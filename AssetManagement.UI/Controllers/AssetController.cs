using AssetManagement.BLL.Provider;
using AssetManagement.DTO.DTO;
using AssetManagement.DTO.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Controllers
{
    public class AssetController : Controller
    {
        NewAssetProvider _pro;
        public AssetController(NewAssetProvider pro)
        {
            _pro = pro;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add()
        {
            AddAssetVM addAssetVM = new AddAssetVM()
            {
                Group = await _pro.GetGroup(),
                Currency=await _pro.GetCurrency(),
                Unit=await _pro.GetUnit(),
                AssetType=await _pro.GetAssetType(),

            };
            return View(addAssetVM);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AssetAdd()
        {
            return View("Add");
        }
    }
}
