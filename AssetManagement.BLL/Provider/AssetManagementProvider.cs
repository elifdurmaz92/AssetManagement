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
        private readonly HttpClient _client;
        public AssetManagementProvider(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Depo Yönetimi sayfasında Tüm varlıklar listesi, Depo yöneticisi tarafında depoda olan bütün varlıkları listeler
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<IEnumerable<AssetListDTO>> WarehouseAssetListGET(int CompanyID, string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            string Query = "EXEC dbo.sp_WarehouseAllAssetList @CompanyID=" + CompanyID + "";
            var getAssetList = await _client.GetAsync("warehouseallassetlist/" + Query);
            if (getAssetList.IsSuccessStatusCode)
            {
                var read = await getAssetList.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<AssetListDTO>>(read);
                return result;
            }
            return null;
        }

        /// <summary>
        /// Personel Kendisine Zimmetlenen varlıkları listeler
        /// </summary>
        /// <param name="PersonnelID"></param>
        /// <param name="token"></param>
        /// <returns></returns>

        public async Task<IEnumerable<AssetListDTO>> PersonnelAssetListGET(int PersonnelID, string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            string Query = "EXEC dbo.sp_PersonnelAssetList @PersonnelID=" + PersonnelID + "";
            var getAssetList = await _client.GetAsync("personnelassetlist/" + Query);
            if (getAssetList.IsSuccessStatusCode)
            {
                var read = await getAssetList.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<AssetListDTO>>(read);
                return result;
            }
            return null;
        }


        public async Task<IEnumerable<AssetListDTO>> TeamAssetListGET(int TeamID, string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            string Query = "EXEC dbo.sp_TeamAssetList @TeamID=" + TeamID + "";
            var getAssetList = await _client.GetAsync("teamassetlist/" + Query);
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
