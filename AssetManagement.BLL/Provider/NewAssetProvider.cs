using AssetManagement.DTO.DTO;
using AssetManagement.DTO.VM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class NewAssetProvider
    {
        HttpClient _client;
        public NewAssetProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<AssetGroupDTO>> GetGroup()
        {
            var getGroup = await _client.GetAsync("assetgroup");
            if (getGroup.IsSuccessStatusCode)
            {
                var read = await getGroup.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<AssetGroupDTO>>(read);
                return result;
            }
            return null;
        }
        public async Task<IEnumerable<CurrencyDTO>> GetCurrency()
        {
            var getCurrency = await _client.GetAsync("currency");

            if (getCurrency.IsSuccessStatusCode)
            {
                var read = await getCurrency.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<CurrencyDTO>>(read);
                return result;

            }
            return null;
        }
        public async Task<IEnumerable<UnitDTO>> GetUnit()
        {
            var getUnit = await _client.GetAsync("unit");

            if (getUnit.IsSuccessStatusCode)
            {
                var read = await getUnit.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<UnitDTO>>(read);
                return result;

            }
            return null;
        }
        public async Task<IEnumerable<AssetTypeDTO>> GetAssetType()
        {
            var getAssetType = await _client.GetAsync("assettype");
            if (getAssetType.IsSuccessStatusCode)
            {
                var read = await getAssetType.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<AssetTypeDTO>>(read);
                return result;
            }
            return null;
        }




    }
}
