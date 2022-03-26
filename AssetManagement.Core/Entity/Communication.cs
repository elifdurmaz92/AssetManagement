using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class Communication:IEntity
    {
        [Key]
        public int ID { get; set; }

        public int PersonnelID { get; set; }

        public int CommTypeID { get; set; }

        public string Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        [ForeignKey("CommTypeID")]
        public virtual CommType CommType { get; set; }

        [ForeignKey("PersonnelID")]
        public virtual Personnel Personnel { get; set; }
    }
}
