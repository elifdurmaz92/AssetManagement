using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.DTO
{
    public class AssetWithoutBarcodeDTO
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public int UnitID { get; set; }
        public decimal Quantity { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
