using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class AssetGroupProvider
    {
        HttpClient _client;
        public AssetGroupProvider(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<AssetGroupDTO>> GetGroup(string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getGroup = await _client.GetAsync("assetgroup");
            if (getGroup.IsSuccessStatusCode)
            {
                var read = await getGroup.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<AssetGroupDTO>>(read);
                return result;
            }
            return null;
        }
    }
}
