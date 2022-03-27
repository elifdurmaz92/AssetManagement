using AssetManagement.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DAL
{
    public interface IAddNewAssetDAL
    {
        void AddNewAsset(AddNewAssetDTO assetVM);
    }
}
