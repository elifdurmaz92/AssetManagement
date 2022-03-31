using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Controllers
{
    public class AssetManagementController : Controller
    {
        public AssetManagementController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
