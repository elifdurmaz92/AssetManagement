using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.DTO
{
    public class AddNewAssetDTO
    {
        public int ID { get; set; }
        public string RegistrationNumber { get; set; }
        public int CompanyID { get; set; }
        public int GroupID { get; set; }
        public int AssetTypeID { get; set; }
        public int AssetBrandID { get; set; }
        public int AssetModelID { get; set; }
        public int CurrencyID { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public bool IsBarcode { get; set; }
        public bool Guarantee { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime RetireDate { get; set; }
        public string Barcode { get; set; }
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }
        public string FilePath { get; set; }
        public decimal AssetPrice { get; set; }
        public int AssetPriceCurrencyID { get; set; }
    }
}
