using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class AssetOwner:IEntity
    {
        [Key]
        public int ID { get; set; }

        public int AssetID { get; set; }

        public int OwnerTypeID { get; set; }

        public int PersonnelID { get; set; }

        public DateTime Date { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual OwnerType OwnerType { get; set; }

        public virtual Personnel Personnel { get; set; }
    }
}
