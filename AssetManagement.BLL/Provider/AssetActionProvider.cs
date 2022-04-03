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

        /// <summary>
        /// Varlık aksiyonlarında Depoya atma, Yorum ekle aksiyonunu gerçekleştirir
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> AddAssetAction(AssetStatusDTO dto, string token = null)
        {
            //static tabloya çıkarburayı
            dto.PersonnelID = 2;
            dto.Date = DateTime.Now;
            dto.CreatedBy = 1;
            dto.CreatedDate = DateTime.Now;
            dto.ModifiedBy = 1;
            dto.ModifiedDate = DateTime.Now;
            dto.IsActive = true;
            var assetstatus = new StringContent(JsonConvert.SerializeObject(dto));
            assetstatus.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            string veri = "";
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var assetstatusPost = await _client.PostAsync("addassetaction", assetstatus);

                if (assetstatusPost.IsSuccessStatusCode)
                {
                    veri = await assetstatusPost.Content.ReadAsStringAsync();
                }
                veri = "başarılı";
            }
            catch (Exception)
            {

                throw;
            }

            return veri;
        }


    }
}
