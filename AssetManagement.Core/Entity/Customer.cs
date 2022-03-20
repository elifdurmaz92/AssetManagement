using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Core.Entity
{
   public class Customer:IEntity
    {
        public int ID { get; set; }
        public string SubscriptionNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<AssetCustomer> AssetCustomer { get; set; }
    }
}
