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
    public class DefinitionController : Controller
    {
        SystemListsProvider _pro;
        public DefinitionController(SystemListsProvider pro)
        {
            _pro = pro;
        }
        public async Task<IActionResult> SystemLists()
        {
            string token = "";
            var list = await _pro.GetSystemList(token);
            if (list!=null)
            {
                return View(list);
            }
            return View(new SystemListsDTO());
        }
    }
}
