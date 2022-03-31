using AssetManagement.DTO.DTO;
using AssetManagement.DTO.VM;
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
            AddAssetVM asset = new AddAssetVM()
            {
                Group = new List<AssetGroupDTO>(),
                Currency = new List<CurrencyDTO>(),
                Unit = new List<UnitDTO>(),
                AssetType = new List<AssetTypeDTO>()
            };
            return View(asset);

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


        /// <summary>
        /// Aksiyonlardan İptal Et Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region İptal Et
        public IActionResult _ToCancel()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ToCancel(string test)
        {

            return RedirectToAction(nameof(Index));
        }
        #endregion

        /// <summary>
        /// Aksiyonlardan Yorum Ekle Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region Yorum Ekle
        public IActionResult _AddComment()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddComment(string test)
        {

            return RedirectToAction(nameof(Index));
        }
        #endregion

        /// <summary>
        /// Aksiyonlardan Kayıp Çalıntı Bildir Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region Kayıp Çalıntı Bildir
        public IActionResult _ReportOfLostOrStolen()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ReportOfLostOrStolen(string test)
        {

            return RedirectToAction(nameof(Index));
        }
        #endregion

        /// <summary>
        /// Aksiyonlardan Emekli Et Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region Emekli Et
        public IActionResult _ToRetire()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ToRetire(string test)
        {

            return RedirectToAction(nameof(Index));
        }
        #endregion

        /// <summary>
        /// Aksiyonlardan İade Et Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region İade Et
        public IActionResult _ToReturn()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ToReturn(string test)
        {

            return RedirectToAction(nameof(Index));
        }
        #endregion


        /// <summary>
        /// Aksiyonlardan Zimmet Ata Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region Zimmet Ata
        public IActionResult _ToOwner()
        {

            return View();
        }
        [HttpPost]
        public IActionResult ToOwner(string test)
        {

            return RedirectToAction(nameof(Index));
        }
        #endregion

    }
}
