using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class ActionStatus:IEntity
    {
        [Key]
        public int ID { get; set; }

        public int AssetActionID { get; set; }

        public int StatusID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual AssetAction AssetAction { get; set; }

        public virtual Status Status { get; set; }
    }
}
