using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class AssetBrand:IEntity
    {
        [Key]
        public int ID { get; set; }
        public int AssetTypeID { get; set; }
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        [ForeignKey("AssetTypeID")]
        public virtual AssetType AssetType { get; set; }
        public virtual ICollection<Asset> Asset { get; set; }

    }
}
