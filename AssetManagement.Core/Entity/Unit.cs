﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AssetManagement.Core.Entity
{
    public class Unit:IEntity
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<AssetWithoutBarcode> AssetWithoutBarcode { get; set; }
    }
}
