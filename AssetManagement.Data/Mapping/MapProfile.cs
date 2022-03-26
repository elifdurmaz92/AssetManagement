using AssetManagement.Core.Entity;
using AssetManagement.DTO.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Data.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AssetType, AssetTypeDTO>();
            CreateMap<AssetTypeDTO, AssetType>();
            CreateMap<AssetGroup, AssetGroupDTO>();
            CreateMap<AssetGroupDTO, AssetGroup>();

        }
    }
}
