﻿using AssetManagement.BLL.Provider;
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
    public class BrandController : Controller
    {
        BrandProvider _pro;
        AssetTypeProvider _typpro;
        public BrandController(BrandProvider pro, AssetTypeProvider typepro)
        {
            _pro = pro;
            _typpro = typepro;
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

        public async Task<IActionResult> Add()
        {
            try
            {
                ViewBag.AssetType = await _typpro.GetAssetType();
                return View(new AssetBrandDTO());
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
          
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(AssetBrandDTO brand)
        {
            try
            {
                var result = await _pro.AddBrand(brand);

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
                var result = await _pro.GetBrandByID(id);
                if (result!=null)
                {
                    ViewBag.AssetType= await _typpro.GetAssetType();
                    return View(result);
                }

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(AssetBrandDTO brand)
        {
            try
            {
                var result = await _pro.UpdateBrand(brand);

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Update",brand.ID);

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
