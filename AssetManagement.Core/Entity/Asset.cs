using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class Asset:IEntity
    {
        [Key]
        public int ID { get; set; }

        public string RegistrationNumber { get; set; }

        public int CompanyID { get; set; }

        public int GroupID { get; set; }

        public int AssetTypeID { get; set; }

        public int MasterDetailID { get; set; }

        public int CurrencyID { get; set; }

        public string Description { get; set; }

        public decimal? Cost { get; set; }

        public bool? Guarantee { get; set; }

        public DateTime? EntryDate { get; set; }

        public DateTime? RetireDate { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual Company Company { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual Group Group { get; set; }

        public virtual MasterDetail MasterDetail { get; set; }

        public virtual AssetType AssetType { get; set; }

        public virtual ICollection<AssetBarcode> AssetBarcode { get; set; }

        public virtual ICollection<AssetCustomer> AssetCustomer { get; set; }

        public virtual ICollection<AssetOwner> AssetOwner { get; set; }

        public virtual ICollection<AssetStatus> AssetStatus { get; set; }

        public virtual ICollection<AssetWithoutBarcode> AssetWithoutBarcode { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }

        public virtual ICollection<Document> Document { get; set; }


        public virtual ICollection<Price> Price { get; set; }
    }
}
