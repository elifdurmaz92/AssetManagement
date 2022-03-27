using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class Asset:IEntity
    {
        [Key]
        public int ID { get; set; }
        public string RegistrationNumber { get; set; }
        public int CompanyID { get; set; }
        public int AssetGroupID { get; set; }
        public int AssetTypeID { get; set; }
        public int AssetBrandID { get; set; }
        public int AssetModelID { get; set; }
        public int CurrencyID { get; set; }
        public string Description { get; set; }
        public decimal? Cost { get; set; }
        public bool? IsBarcode { get; set; }
        public bool? Guarantee { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? RetireDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }

        [ForeignKey("CurrencyID")]
        public virtual Currency Currency { get; set; }

        [ForeignKey("AssetGroupID")]
        public virtual AssetGroup AssetGroup { get; set; }

        [ForeignKey("AssetBrandID")]
        public virtual AssetBrand AssetBrand { get; set; }

        [ForeignKey("AssetModelID")]
        public virtual AssetModel AssetModel { get; set; }

        [ForeignKey("AssetTypeID")]
        public virtual AssetType AssetType { get; set; }

        public virtual ICollection<AssetBarcode> AssetBarcode { get; set; }
        public virtual ICollection<AssetCustomer> AssetCustomer { get; set; }
        public virtual ICollection<AssetOwner> AssetOwner { get; set; }
        public virtual ICollection<AssetStatus> AssetStatus { get; set; }
        public virtual ICollection<AssetWithoutBarcode> AssetWithoutBarcode { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<AssetDocument> AssetDocument { get; set; }
        public virtual ICollection<AssetPrice> AssetPrice { get; set; }
    }
}
