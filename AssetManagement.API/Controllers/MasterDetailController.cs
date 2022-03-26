using AssetManagement.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDetailController : ControllerBase
    {
        IMasterDetailDAL _dal;
        public MasterDetailController(IMasterDetailDAL dal)
        {
            _dal = dal;
        }
    }
}
