using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.DTO
{
    public class AssetActionDetailDTO
    {
        public int RegistrationNumber { get; set; }
        public int AssetID { get; set; }
        public AssetActionListDTO AssetActionListDTO { get; set; }
        public IEnumerable<ActionStatusDTO> ActionStatusDTO { get; set; }

    }
}
