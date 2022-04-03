using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class AssetActionProvider
    {
        HttpClient _client;
        public AssetActionProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<AssetActionDetailDTO> GetAssetActionDetail(int registrationNumber,string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getActionDetail = await _client.GetAsync("getassetaction/"+ registrationNumber);
            if (getActionDetail.IsSuccessStatusCode)
            {
                var read = await getActionDetail.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AssetActionDetailDTO>(read);
                return result;
            }
            return null;
        }
    }
}
