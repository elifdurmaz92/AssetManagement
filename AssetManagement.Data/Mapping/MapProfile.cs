﻿using AssetManagement.Core.Entity;
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

            CreateMap<AssetGroup, AssetGroupDTO>().ReverseMap();
            CreateMap<AssetGroupDTO, AssetGroup>().ReverseMap();

            CreateMap<AssetBrand, AssetBrandDTO>();
            CreateMap<AssetBrandDTO, AssetBrand>();

            CreateMap<AssetModel, AssetModelDTO>();
            CreateMap<AssetModelDTO, AssetModel>();

            CreateMap<Unit, UnitDTO>();
            CreateMap<UnitDTO, Unit>();

            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>();

            CreateMap<AssetStatus, AssetStatusDTO>();
            CreateMap<AssetStatusDTO, AssetStatus>();

            CreateMap<AssetWithoutBarcode, AssetWithoutBarcodeDTO>();
            CreateMap<AssetWithoutBarcodeDTO, AssetWithoutBarcode>();

            CreateMap<AssetBarcode, AssetBarcodeDTO>();
            CreateMap<AssetBarcodeDTO, AssetBarcode>();

            CreateMap<AssetPrice, AssetPriceDTO>();
            CreateMap<AssetPriceDTO, AssetPrice>();

            CreateMap<AssetDocument, AssetDocumentDTO>();
            CreateMap<AssetDocumentDTO, AssetDocument>();

            CreateMap<Asset, AssetDTO>();
            CreateMap<AssetDTO, Asset>();

            CreateMap<SystemLists, SystemListsDTO>();
            CreateMap<SystemListsDTO, SystemLists>();

            CreateMap<WarehouseAllAssetList, AssetListDTO>();
            CreateMap<AssetListDTO, WarehouseAllAssetList>();

            CreateMap<ActionStatus, ActionStatusDTO>();
            CreateMap<ActionStatusDTO, ActionStatus>();

        }
    }
}
