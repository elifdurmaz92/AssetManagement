using AssetManagement.BLL.Provider;
using AssetManagement.DTO.DTO;
using AssetManagement.DTO.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Models.Viewcomponent
{
    public class PersonnelAssetListViewComponent:ViewComponent
    {
        private readonly AssetManagementProvider _pro;
        public PersonnelAssetListViewComponent(AssetManagementProvider pro)
        {
            _pro = pro;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                //Identity konusuna başlayınca burayı dinamik alacaksın
                int PersonnelID = 2;
                var result = await _pro.PersonnelAssetListGET(PersonnelID);
                ViewBag.CountPers = result.Count();
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
