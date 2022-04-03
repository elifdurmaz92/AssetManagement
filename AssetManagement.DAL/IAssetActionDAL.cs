using AssetManagement.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DAL
{
    public interface IAssetActionDAL
    {
       Task<AssetActionDetailDTO> AssetActionDetailGET(int registrationNumber);
    }
}
