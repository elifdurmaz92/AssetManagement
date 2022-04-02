using AssetManagement.BLL.Provider;
using AssetManagement.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Models.Viewcomponent
{
    public class TeamAssetListViewComponent:ViewComponent
    {
        private readonly AssetManagementProvider _pro;
        public TeamAssetListViewComponent(AssetManagementProvider pro)
        {
            _pro = pro;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                //Identity konusuna başlayınca burayı dinamik alacaksın
                int TeamID = 1;
                var result = await _pro.TeamAssetListGET(TeamID);
                ViewBag.CountTeam = result.Count();
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
