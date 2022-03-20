using AssetManagement.DTO.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Controllers
{
    public class AuthController : Controller
    {
        //DAL katmanı koyarak devam et direk repoyu çağırma!!!

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginIn(LoginVM loginVM)
        {
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
