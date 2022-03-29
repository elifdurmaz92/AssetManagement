using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.DTO
{
    public class AssetStatusDTO
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public int PersonnelID { get; set; }
        public int StatusID { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
