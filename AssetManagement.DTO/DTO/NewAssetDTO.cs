using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.DTO.DTO
{
    public class NewAssetDTO
    {
        public IEnumerable<AssetGroupDTO> Group { get; set; }
        public IEnumerable<AssetTypeDTO> AssetType { get; set; }
        public IEnumerable<CurrencyDTO> Currency { get; set; }
        public IEnumerable<UnitDTO> Unit { get; set; }
    }
}
