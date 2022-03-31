using AssetManagement.BLL.Provider;
using AssetManagement.DTO.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        BrandProvider _pro;
        public BrandController(BrandProvider pro)
        {
            _pro = pro;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _pro.GetBrandList();
                if (result != null)
                {
                    return View(result);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return View(new AssetBrandVM());
        }

        public IActionResult Add()
        {


            return View();
        }

        [HttpPost]
        //public IActionResult Add()
        //{


        //    return View();
        //}
        public IActionResult Update(int id)
        {


            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var sonuc=await _pro.Delete(id);

            //Çalışmıyor burası tekrar bak
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

    }
}
