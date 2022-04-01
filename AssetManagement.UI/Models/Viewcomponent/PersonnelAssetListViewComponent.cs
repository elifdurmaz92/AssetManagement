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
        public IViewComponentResult Invoke()
        {

            //var deger = new List<AssetModelVM> {
            //    new AssetModelVM(){Description="hede"},
            //    new AssetModelVM(){Description="bidi"}

            //};
            //return View(deger);
            return View();
        }
    }
}
