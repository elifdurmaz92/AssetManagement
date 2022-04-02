using AssetManagement.BLL.Provider;
using AssetManagement.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Models.Viewcomponent
{
    public class AllAssetListViewComponent:ViewComponent
    {
        AssetManagementProvider _pro;
        public AllAssetListViewComponent(AssetManagementProvider pro)
        {
            _pro = pro;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                //Identity konusuna başlayınca burayı dinamik alacaksın
                int CompanyID = 1;
                var result = await _pro.WarehouseAssetListGET(CompanyID);
                if (result != null)
                {
                    return View(result);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return View(new AssetListDTO());
        }
    }
}
