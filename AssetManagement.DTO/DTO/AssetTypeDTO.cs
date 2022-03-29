using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.DTO
{
    public class AssetTypeDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
