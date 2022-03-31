using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.VM
{
    public class AssetModelVM
    {
        public int ID { get; set; }
        public string AssetBrand { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
