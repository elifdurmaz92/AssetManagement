using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Controllers
{
    public class AssetActionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Aksiyonlardan Depoya Ata Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region Depoya Ata
        public IActionResult _PutInStorage()
        {

            return View();
        }

        [HttpPost]
        public IActionResult PutInStorage(string test)
        {

            return RedirectToAction(nameof(Index));
        }
        #endregion

        /// <summary>
        /// Aksiyonlardan Tüket Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region Tüket
        public IActionResult _ToConsume()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ToConsume(string test)
        {

            return RedirectToAction(nameof(Index));
        } 
        #endregion
    }
}
