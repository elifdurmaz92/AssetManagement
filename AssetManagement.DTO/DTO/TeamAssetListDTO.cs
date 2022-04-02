using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.DTO
{
    public class TeamAssetListDTO
    {
        public int ID { get; set; }
        public int RegistrationNumber { get; set; }
        public string Barcode { get; set; }
        public string AssetType { get; set; }
        public decimal CurrentPrice { get; set; }
        public string AssetBrand { get; set; }
        public string AssetModel { get; set; }
    }
}
