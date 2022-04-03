using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.Core.Entity
{
   public class Status:IEntity
    {
        [Key]
        public int ID { get; set; }
        public int MasterID { get; set; }
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<ActionStatus> ActionStatus { get; set; }

        public virtual ICollection<AssetStatus> AssetStatus { get; set; }
    }
}
