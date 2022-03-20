using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class Personnel : IEntity
    {
        [Key]
        public int ID { get; set; }

        public int CompanyID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<AssetOwner> AssetOwner { get; set; }

        public virtual ICollection<AssetStatus> AssetStatus { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }

        public virtual ICollection<Communication> Communication { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<PersonnelLoginInfo> PersonnelLoginInfo { get; set; }

        public virtual ICollection<PersonnelTeam> PersonnelTeam { get; set; }

        public virtual ICollection<RolePersonnel> RolePersonnel { get; set; }
    }
}
