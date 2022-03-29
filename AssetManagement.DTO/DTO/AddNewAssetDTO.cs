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
        public int AssetGroupID { get; set; }
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

        //barcodlu
        public string Barcode { get; set; }

        //assetStatus
        public int PersonnelID { get; set; }
        public string StatusNote { get; set; }
        public DateTime Date { get; set; }

        //barkodsuz
        public decimal Quantity { get; set; }
        public int UnitID { get; set; }

        //dokuman
        public string FilePath { get; set; }
        public string PageCode { get; set; }

        //fiyat
        public decimal AssetPrice { get; set; }
        public int AssetPriceCurrencyID { get; set; }


        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
