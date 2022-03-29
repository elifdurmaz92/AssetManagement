using AssetManagement.BLL.Provider;
using AssetManagement.DTO.DTO;
using AssetManagement.DTO.VM;
using AutoMapper;
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
        NewAssetProvider _newAssetpro;
        AssetProvider _assetpro;
        IMapper _mapper;
        public AssetController(NewAssetProvider newAssetpro, AssetProvider assetpro,IMapper mapper)
        {
            _newAssetpro = newAssetpro;
            _assetpro = assetpro;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Asset ekleme sayfası
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Add()
        {
            AddAssetVM addAssetVM = new AddAssetVM()
            {
                Group = await _newAssetpro.GetGroup(),
                Currency = await _newAssetpro.GetCurrency(),
                Unit = await _newAssetpro.GetUnit(),
                AssetType = await _newAssetpro.GetAssetType(),
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
            var getBrand = await _newAssetpro.GetBrandByType(assetTypeID);

            return Json(getBrand);
        }

        /// <summary>
        /// Varlık Markasına göre modelleri getirir
        /// </summary>
        /// <param name="assetBrandID"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetModelByAssetType(int assetBrandID)
        {
            var getModel = await _newAssetpro.GetModelByBrand(assetBrandID);

            return Json(getModel);
        }
        

        [HttpPost]
        public IActionResult AssetAdd(AddAssetVM assetVM)
        {
            var result=_assetpro.AddNewAsset(_mapper.Map<AddNewAssetDTO>(assetVM));
            
            return View("Add");
        }
    }
}
