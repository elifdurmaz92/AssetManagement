using AssetManagement.BLL.Provider;
using AssetManagement.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AssetGroupController : Controller
    {
        private readonly AssetGroupProvider _pro;
        public AssetGroupController(AssetGroupProvider pro)
        {
            _pro = pro;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _pro.GetGroup();
                if (result != null)
                {
                    return View(result);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return View(new AssetGroupDTO());
        }

        public IActionResult Add()
        {
            return View(new AssetGroupDTO());
        }

        [HttpPost]
        public async Task<IActionResult> AddAssetGroup(AssetGroupDTO group)
        {
            try
            {
                var result = await _pro.AddGroup(group);
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
                var result = await _pro.GetGroupByID(id);
                if (result != null)
                {
                    return View(result);
                }

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateGroup(AssetGroupDTO group)
        {
            try
            {
                var result = await _pro.UpdateGroup(group);

            }
            catch (Exception)
            {

            }
            return RedirectToAction("Update", group.ID);

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
