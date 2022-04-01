using AssetManagement.DTO.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.DAL
{
    public class NewAssetDAL : INewAssetDAL
    {
        private readonly IAssetTypeDAL _typeDAL;
        private readonly IUnitDAL _unitDAL;
        private readonly ICurrencyDAL _curDAL;
        private readonly IAssetGroupDAL _groupDAL;
        private static IMapper _map;
        public NewAssetDAL(IAssetTypeDAL typeDAL, IUnitDAL unitDAL, ICurrencyDAL curDAL, IAssetGroupDAL groupDAL, IMapper map)
        {
            _typeDAL = typeDAL;
            _unitDAL = unitDAL;
            _curDAL = curDAL;
            _groupDAL = groupDAL;
            _map = map;
        }
        public async Task<NewAssetDTO> NewGetAsset()
        {
            try
            {

                var group = await _groupDAL.GetAllAsync();
                var assetType = await _typeDAL.GetAllAsync();
                var unit = await _unitDAL.GetAllAsync();
                var currency = await _curDAL.GetAllAsync();
                NewAssetDTO newAsset = new NewAssetDTO()
                {
                    Group = _map.Map<IEnumerable<AssetGroupDTO>>(group),
                    AssetType = _map.Map<IEnumerable<AssetTypeDTO>>(assetType),
                    Unit = _map.Map<IEnumerable<UnitDTO>>(unit),
                    Currency = _map.Map<IEnumerable<CurrencyDTO>>(currency)
                };


                return newAsset;
            }
            catch (Exception)
            {

                return (new NewAssetDTO()
                {
                    Group = new List<AssetGroupDTO>() { },
                    AssetType = new List<AssetTypeDTO>() { },
                    Unit= new List<UnitDTO>() { },
                    Currency= new List<CurrencyDTO>() { }

                });
            }



        }
    }
}
