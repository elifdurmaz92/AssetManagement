using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Models.Viewcomponent
{
    public class TeamAssetListViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
