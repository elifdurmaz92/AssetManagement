using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class PageClaimDetail:IEntity
    {
        [Key]
        public int ID { get; set; }

        public int RoleID { get; set; }

        public int PageID { get; set; }

        public int ClaimID { get; set; }

        public string Date { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual PageClaim PageClaim { get; set; }

        public virtual Page Page { get; set; }

        public virtual Role Role { get; set; }
    }
}
