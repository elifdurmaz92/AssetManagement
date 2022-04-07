using AssetManagement.BLL.Common;
using AssetManagement.BLL.Provider;
using AssetManagement.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Controllers
{
    public class AuthController : Controller
    {
        AuthProvider _pro;
        public AuthController(AuthProvider pro)
        {
            _pro = pro;
        }
        public IActionResult Login()
        {

            return View(new LoginDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var token = await _pro.GetToken(loginDTO);
                if (token != null)
                {
                    HttpContext.Session.MySessionSet("token", token);
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (Exception exc)
            {

            }
            return RedirectToAction("Login");
        }
        public IActionResult LogOut()
        {
            return View();
        }

    }
}
