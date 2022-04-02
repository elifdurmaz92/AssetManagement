using AssetManagement.Core.Context;
using AssetManagement.Core.Entity;
using AssetManagement.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DAL
{
    public class WarehouseManagementDAL: EfRepoBase<WarehouseAllAssetList, AssetManagementContext>, IWarehouseManagementDAL
    {
    }
}
