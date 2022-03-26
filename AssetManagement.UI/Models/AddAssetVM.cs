using AssetManagement.UI.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.UI.Models
{
    public class AddAssetVM
    {
        public int ID { get; set; }

        public string RegistrationNumber { get; set; }

        public int CompanyID { get; set; }

        public int GroupID { get; set; }

        public int AssetTypeID { get; set; }

        public int MasterDetailID { get; set; }

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

        List<AssetGroupVM> Group { get; set; }
        List<AssetTypeVM> AssetType { get; set; }
        List<BrandVM> Brand { get; set; }
        List<ModelVM> Model { get; set; }
        List<CurrencyVM> Currency { get; set; }
        List<UnitVM> Unit { get; set; }
        GuaranteeEnum IsGuarantee { get; set; }

    }
}
