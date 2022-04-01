using AssetManagement.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DAL
{
    public interface INewAssetDAL
    {
        Task<NewAssetDTO> NewGetAsset();
    }
}
