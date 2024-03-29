﻿using AssetManagement.DTO.DTO;
using AssetManagement.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.VM
{
    public class AddAssetVM
    {
        public int ID { get; set; }
        public int RegistrationNumber { get; set; }
        public int CompanyID { get; set; }
        public int AssetGroupID { get; set; }
        public int AssetTypeID { get; set; }
        public int AssetBrandID { get; set; }
        public int AssetModelID { get; set; }
        public int CurrencyID { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public bool IsBarcode { get; set; }
        public bool Guarantee { get; set; }
        public DateTime EntryDate { get; set; } = DateTime.Now.Date;
        public DateTime RetireDate { get; set; } = DateTime.Now.Date;

        public string Barcode { get; set; }
        public decimal? Quantity { get; set; }
        public int? UnitID { get; set; }
        public string FilePath { get; set; }

        public decimal? AssetPrice { get; set; }
        public int? AssetPriceCurrencyID { get; set; }

        public IEnumerable<AssetGroupDTO> Group { get; set; }
        public IEnumerable<AssetTypeDTO> AssetType { get; set; }
        public IEnumerable<CurrencyDTO> Currency { get; set; }
        public IEnumerable<UnitDTO> Unit { get; set; }

    }
}
