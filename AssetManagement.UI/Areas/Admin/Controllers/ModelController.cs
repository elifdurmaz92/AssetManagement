using AssetManagement.BLL.Provider;
using AssetManagement.DTO.DTO;
using AssetManagement.DTO.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModelController : Controller
    {
        AssetModelProvider _pro;
        BrandProvider _brandpro;
        public ModelController(AssetModelProvider pro,BrandProvider brandpro)
        {
            _pro = pro;
            _brandpro = brandpro;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _pro.GetModelList();
                if (result != null)
                {
                    return View(result);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(new AssetModelVM());
        }

        public async Task<IActionResult> Add()
        {
            try
            {
                ViewBag.AssetBrand = await _brandpro.GetBrand();
                return View(new AssetModelDTO());
            }
            catch (Exception)
            {

                return RedirectToAction("Index");
            }        
        }

        [HttpPost]
        public async Task<IActionResult> AddModel(AssetModelDTO model)
        {
            try
            {
                var result = await _pro.AddModel(model);

            }
            catch (Exception)
            {

            }
            return View("Add");
        }

        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var result = await _pro.GetModelByID(id);
                if (result != null)
                {
                    ViewBag.AssetBrand = await _brandpro.GetBrand();
                    return View(result);
                }

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateModel(AssetModelDTO model)
        {
            try
            {
                var result = await _pro.UpdateModel(model);

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Update", model.ID);

        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var sonuc = await _pro.Delete(id);

            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
    }
}
