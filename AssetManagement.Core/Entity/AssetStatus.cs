using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class AssetStatus:IEntity
    {
        [Key]
        public int ID { get; set; }

        public int AssetID { get; set; }

        public int PersonnelID { get; set; }

        public int StatusID { get; set; }

        public string Note { get; set; }

        public string Date { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual Personnel Personnel { get; set; }

        public virtual Status Status { get; set; }
    }
}
