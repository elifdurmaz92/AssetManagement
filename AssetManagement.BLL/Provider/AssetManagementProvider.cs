using AssetManagement.DTO.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.BLL.Provider
{
    public class AssetManagementProvider
    {
        HttpClient _client;
        public AssetManagementProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<AssetListDTO>> WarehouseAssetListGET(int CompanyID,string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            string Query = "EXEC dbo.sp_WarehouseAllAssetList @CompanyID=" + CompanyID + "";
            var getAssetList =await _client.GetAsync("warehouseallassetlist/"+ Query);
            if (getAssetList.IsSuccessStatusCode)
            {
                var read = await getAssetList.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<AssetListDTO>>(read);
                return result;
            }
            return null;
        }
    }
}
