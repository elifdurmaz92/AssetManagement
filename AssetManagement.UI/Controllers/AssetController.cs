using AssetManagement.BLL.Provider;
using AssetManagement.DTO.DTO;
using AssetManagement.DTO.VM;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
                Currency = await _pro.GetCurrency(),
                Unit = await _pro.GetUnit(),
                AssetType = await _pro.GetAssetType(),
                AssetPrice=new AssetPriceDTO()

            };
            return View(addAssetVM);
        }

        /// <summary>
        /// Varlık tipine göre Markaları getirir
        /// </summary>
        /// <param name="assetTypeID"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetBrandByAssetType(int assetTypeID)
        {
            var getBrand = await _pro.GetBrandByType(assetTypeID);

            return Json(getBrand);
        }

        /// <summary>
        /// Varlık Markasına göre modelleri getirir
        /// </summary>
        /// <param name="assetBrandID"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetModelByAssetType(int assetBrandID)
        {
            var getModel = await _pro.GetModelByBrand(assetBrandID);

            return Json(getModel);
        }
        

        [HttpPost]
        public IActionResult AssetAdd(AddAssetVM assetVM)
        {
            if (assetVM.IsBarcode==true)
            {


            }
            else
            {

            }
            var deger = assetVM;
            return View("Add");
        }
    }
}
