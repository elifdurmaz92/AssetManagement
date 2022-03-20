using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class Price:IEntity
    {
        [Key]
        public int ID { get; set; }

        public int AssetID { get; set; }
        public decimal Price1 { get; set; }

        public int CurrencyID { get; set; }

        public DateTime Date { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual Currency Currency { get; set; }
    }
}
