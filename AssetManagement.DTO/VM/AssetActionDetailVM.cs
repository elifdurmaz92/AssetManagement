using AssetManagement.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.VM
{
    public class AssetActionDetailVM
    {
        public int RegistrationNumber { get; set; }

        public IEnumerable<AssetActionDetailDTO> AssetActionDetailDTO { get; set; }
        public IEnumerable<ActionStatusDTO> ActionStatusDTO { get; set; }
    }
}
