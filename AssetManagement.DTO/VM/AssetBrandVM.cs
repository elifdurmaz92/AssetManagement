using AssetManagement.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.VM
{
    public class AssetBrandVM
    {
        public int ID { get; set; }
        public string AssetType { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

    }
}
