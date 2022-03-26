using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class PersonnelTeam:IEntity
    {
        [Key]
        public int ID { get; set; }

        public int PersonnelID { get; set; }

        public int TeamID { get; set; }

        public DateTime Date { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        [ForeignKey("PersonnelID")]
        public virtual Personnel Personnel { get; set; }

        [ForeignKey("TeamID")]
        public virtual Team Team { get; set; }
    }
}
