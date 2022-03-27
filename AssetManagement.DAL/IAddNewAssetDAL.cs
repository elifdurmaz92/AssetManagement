using AssetManagement.DTO.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DAL
{
    public interface IAddNewAssetDAL
    {
        void AddNewAsset(AddAssetVM assetVM);
    }
}
