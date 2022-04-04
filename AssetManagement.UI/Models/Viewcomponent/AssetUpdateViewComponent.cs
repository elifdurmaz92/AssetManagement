using AssetManagement.DTO.DTO;
using AssetManagement.DTO.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Models.Viewcomponent
{
    public class AssetUpdateViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke(int assetID)
        {
            AddAssetVM asset = new AddAssetVM()
            {
                Group = new List<AssetGroupDTO>(),
                Currency = new List<CurrencyDTO>(),
                Unit = new List<UnitDTO>(),
                AssetType = new List<AssetTypeDTO>()
            };

            return View(asset);
        }
    }
}
