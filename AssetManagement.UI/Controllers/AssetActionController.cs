using AssetManagement.BLL.Provider;
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
        AssetActionProvider _pro;
        public AssetActionController(AssetActionProvider pro)
        {
            _pro = pro;
        }
        public IActionResult Index(AssetActionDetailDTO assetaction =null)
        {
            if (assetaction.AssetActionListDTO==null)
            {
                assetaction = new AssetActionDetailDTO()
                {
                    AssetActionListDTO = new AssetActionListDTO() { },
                    ActionStatusDTO = new List<ActionStatusDTO>() { new ActionStatusDTO() { } }
                };

            }

            return View(assetaction);

        }

        [HttpPost]
        public async Task<IActionResult> GetActionAsset(AssetActionDetailDTO assetaction)
        {
            try
            {
                var result = await _pro.GetAssetActionDetail(assetaction.RegistrationNumber);
                if (result != null)
                {
                    return View("Index", result);

                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }



        /// <summary>
        /// Aksiyonlardan Depoya Ata Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region Depoya Ata
        public IActionResult _PutInStorage(int assetID,int statusActionID)
        {
            AssetStatusDTO assetStatus = new AssetStatusDTO()
            {
                StatusID = statusActionID,
                AssetID = assetID
            };

            return View(assetStatus);
        }

        [HttpPost]
        public IActionResult PutInStorage(AssetStatusDTO assetstatus)
        {
            var result = _pro.AddAssetAction(assetstatus);
            if (result==null)
            {
                ViewBag.mesaj = "Hata";

            }
            else
            {
                ViewBag.mesaj = "İşlem Başarılı";
            }

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
        public IActionResult _ToCancel(int assetID, int statusActionID)
        {
            AssetStatusDTO assetStatus = new AssetStatusDTO()
            {
                StatusID = statusActionID,
                AssetID = assetID
            };

            return View(assetStatus);
        }
        [HttpPost]
        public IActionResult ToCancel(AssetStatusDTO assetstatus)
        {
            var result = _pro.AddAssetAction(assetstatus);
            if (result == null)
            {
                ViewBag.mesaj = "Hata";
            }
            else
            {
                ViewBag.mesaj = "İşlem Başarılı";
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        /// <summary>
        /// Aksiyonlardan Yorum Ekle Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region Yorum Ekle
        public IActionResult _AddComment(int assetID, int statusActionID)
        {
            AssetStatusDTO assetStatus = new AssetStatusDTO()
            {
                StatusID = statusActionID,
                AssetID = assetID
            };

            return View(assetStatus);
        }
        [HttpPost]
        public IActionResult AddComment(AssetStatusDTO assetstatus)
        {
            var result = _pro.AddAssetAction(assetstatus);
            if (result == null)
            {
                ViewBag.mesaj = "Hata";

            }
            else
            {
                ViewBag.mesaj = "İşlem Başarılı";
            }

            return RedirectToAction(nameof(Index));
        }
        #endregion

        /// <summary>
        /// Aksiyonlardan Kayıp Çalıntı Bildir Modal sayfasının açılması
        /// </summary>
        /// <returns></returns>
        #region Kayıp Çalıntı Bildir
        public IActionResult _ReportOfLostOrStolen(int assetID, int statusActionID)
        {
            AssetStatusDTO assetStatus = new AssetStatusDTO()
            {
                StatusID = statusActionID,
                AssetID = assetID
            };

            return View(assetStatus);
        }
        [HttpPost]
        public IActionResult ReportOfLostOrStolen(AssetStatusDTO assetstatus)
        {
            var result = _pro.AddAssetAction(assetstatus);
            if (result == null)
            {
                ViewBag.mesaj = "Hata";
            }
            else
            {
                ViewBag.mesaj = "İşlem Başarılı";
            }

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
