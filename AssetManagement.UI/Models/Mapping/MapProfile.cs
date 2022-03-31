using AssetManagement.DTO.DTO;
using AssetManagement.DTO.VM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Models.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AddNewAssetDTO, AddAssetVM>();
            CreateMap<AddAssetVM, AddNewAssetDTO>();

        }
    }
}
