using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AssetManagement.BLL.Provider
{
    public class AssetProvider
    {
        HttpClient _client;
        public AssetProvider(HttpClient client)
        {
            _client = client;
        }

        public void AddAsset()
        {


        }


    }
}
