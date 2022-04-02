using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssetManagement.Core.Entity
{
    [Table("TeamAssetList", Schema = "sp_TeamAssetList")]
    public class TeamAssetList:IEntity
    {
        [Key]
        public int ID { get; set; }
        public int RegistrationNumber { get; set; }
        public string Barcode { get; set; }
        public string AssetType { get; set; }
        public decimal CurrentPrice { get; set; }
        public string AssetBrand { get; set; }
        public string AssetModel { get; set; }
    }
}
