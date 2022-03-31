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
        AssetProvider _assetpro;
        AssetTypeProvider _assetTypepro;
        UnitProvider _unitpro;
        CurrencyProvider _currencypro;
        AssetModelProvider _modelpro;
        BrandProvider _brandpro;
        AssetGroupProvider _grouppro;
        IMapper _mapper;
        #endregion
        public AssetController(AssetProvider assetpro, AssetTypeProvider assetTypepro, UnitProvider unitpro, CurrencyProvider currencypro, AssetModelProvider modelpro, BrandProvider brandpro, AssetGroupProvider grouppro, IMapper mapper)
        {
            _assetpro = assetpro;
            _assetTypepro = assetTypepro;
            _unitpro = unitpro;
            _currencypro = currencypro;
            _modelpro = modelpro;
            _brandpro = brandpro;
            _grouppro = grouppro;
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
                AddAssetVM addAssetVM = new AddAssetVM()
                {
                    Group = await _grouppro.GetGroup(),
                    Currency = await _currencypro.GetCurrency(),
                    Unit = await _unitpro.GetUnit(),
                    AssetType = await _assetTypepro.GetAssetType(),
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

            return RedirectToAction("Add");
        }
    }
}
