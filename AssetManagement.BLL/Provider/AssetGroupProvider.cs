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

        public async Task<string> AddGroup(AssetGroupDTO dto, string token = null)
        {
            //static tabloya çıkarburayı
            dto.CreatedBy = 1;
            dto.CreatedDate = DateTime.Now;
            dto.ModifiedBy = 1;
            dto.ModifiedDate = DateTime.Now;
            dto.IsActive = true;
            var group = new StringContent(JsonConvert.SerializeObject(dto));
            group.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            string veri = "";
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var groupPost = await _client.PostAsync("addassetgroup", group);

                if (groupPost.IsSuccessStatusCode)
                {
                    veri = await groupPost.Content.ReadAsStringAsync();
                }
                veri = "başarılı";
            }
            catch (Exception)
            {

                throw;
            }

            return veri;
        }
        public async Task<AssetGroupDTO> GetGroupByID(int id, string token = null)
        {
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var getGroup = await _client.GetAsync("getgroupbyid/" + id);

            if (getGroup.IsSuccessStatusCode)
            {
                var groupTrans = await getGroup.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AssetGroupDTO>(groupTrans);
                return result;
            }
            else { }

            return null;
        }

        public async Task<string> UpdateGroup(AssetGroupDTO dto, string token = null)
        {
            var groupTrans = new StringContent(JsonConvert.SerializeObject(dto));
            groupTrans.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            string veri = "";
            try
            {
                _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var updateGroup = await _client.PutAsync("updateassetgroup", groupTrans);

                if (updateGroup.IsSuccessStatusCode)
                {
                    veri = await updateGroup.Content.ReadAsStringAsync();
                }
                veri = "başarılı";
            }
            catch (Exception)
            {

                throw;
            }

            return veri;
        }

        public async Task<string> Delete(int id, string token = null)
        {
            try
            {
                string veri = "";
                var group = await GetGroupByID(id);
                //sonra geri al unutma
                //_client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var groupTrans = new StringContent(JsonConvert.SerializeObject(group));
                groupTrans.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var deleteBrand = await _client.PutAsync("deleteassetgroup", groupTrans);
                if (deleteBrand.IsSuccessStatusCode)
                {
                    veri = "silindi..";
                }
                return veri;
            }
            catch (Exception exc)
            {
                var hata = "hata" + exc;
                throw;
            }
        }
    }
}
