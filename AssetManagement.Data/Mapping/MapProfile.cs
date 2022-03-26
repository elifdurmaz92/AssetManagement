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

            CreateMap<Price, PriceDAL>();
            CreateMap<PriceDAL, Price>();

            CreateMap<AssetDocument, AssetDocumentDTO>();
            CreateMap<AssetDocumentDTO, AssetDocument>();

            CreateMap<Asset, AssetDTO>();
            CreateMap<AssetDTO, Asset>();
        }
    }
}
