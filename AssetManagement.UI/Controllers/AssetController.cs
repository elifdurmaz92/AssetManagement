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
        #region Fields
        private readonly AssetProvider _assetpro;
        private readonly AssetModelProvider _modelpro;
        private readonly BrandProvider _brandpro;
        private readonly IMapper _mapper;
        #endregion
        public AssetController(AssetProvider assetpro, AssetModelProvider modelpro, BrandProvider brandpro, IMapper mapper)
        {
            _assetpro = assetpro;
            _modelpro = modelpro;
            _brandpro = brandpro;
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
            try
            {
                var value = await _assetpro.NewAssetGET();

                AddAssetVM addAssetVM = new AddAssetVM()
                {
                    Group = value.Group,
                    Currency = value.Currency,
                    Unit = value.Unit,
                    AssetType = value.AssetType,
                };
                return View(addAssetVM);
            }
            catch (Exception)
            {

            }

            AddAssetVM asset = new AddAssetVM() {
                Group =new List<AssetGroupDTO>(),
                Currency=new List<CurrencyDTO>(),
                Unit=new List<UnitDTO>(),
                AssetType=new List<AssetTypeDTO>()
            };
            return View(asset);
        }

        /// <summary>
        /// Varlık tipine göre Markaları getirir
        /// </summary>
        /// <param name="assetTypeID"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetBrandByAssetType(int assetTypeID)
        {
            var getBrand = await _brandpro.GetBrandByType(assetTypeID);

            return Json(getBrand);
        }

        /// <summary>
        /// Varlık Markasına göre modelleri getirir
        /// </summary>
        /// <param name="assetBrandID"></param>
        /// <returns></returns>
        public async Task<JsonResult> GetModelByAssetType(int assetBrandID)
        {
            var getModel = await _modelpro.GetModelByBrand(assetBrandID);

            return Json(getModel);
        }


        [HttpPost]
        public IActionResult AssetAdd(AddAssetVM assetVM)
        {
            var result = _assetpro.AddNewAsset(_mapper.Map<AddNewAssetDTO>(assetVM));
            ViewBag.mesaj = result;
            return RedirectToAction("Add");
        }

    }
}
