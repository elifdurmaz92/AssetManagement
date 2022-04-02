using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class AssetTypeProvider
    {
        private readonly HttpClient _client;
        public AssetTypeProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<AssetTypeDTO>> GetAssetType(string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
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
