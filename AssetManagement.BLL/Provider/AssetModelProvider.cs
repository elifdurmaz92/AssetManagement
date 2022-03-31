using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class AssetModelProvider
    {
        HttpClient _client;
        public AssetModelProvider(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<AssetModelDTO>> GetModelByBrand(int assetBrandID, string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getBrand = await _client.GetAsync("getModelByBrand/" + assetBrandID);
            if (getBrand.IsSuccessStatusCode)
            {
                var read = await getBrand.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<AssetModelDTO>>(read);
                return result;
            }
            return null;
        }
    }
}
