using AssetManagement.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.VM
{
    public class AddBrandVM
    {
        public int ID { get; set; }
        public int AssetTypeID { get; set; }
        public string Description { get; set; }
        public IEnumerable<AssetTypeDTO> AssetType { get; set; }
    }
}
