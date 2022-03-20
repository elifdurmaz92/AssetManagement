using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class CommType:IEntity
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<Communication> Communication { get; set; }
    }
}
