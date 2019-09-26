using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wy.Nacos.Configuration;

namespace Wy.Nacos.Core
{
    public class NacosConfigApi : INacosConfigApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NacosConfigApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Result<string>> GetAsync(NacosConfig config)
        {
            var client = _httpClientFactory.CreateClient(NacosHttpConsts.HttpService);
            var response = await client.GetAsync($"{NacosRequestUrlConsts.ConfigUrl}{config.ToString()}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new Result<string>(response.StatusCode, await response.Content.ReadAsStringAsync());
            }
            return new Result<string>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Result<T>> GetAsync<T>(NacosConfig config)
        {
            var client = _httpClientFactory.CreateClient(NacosHttpConsts.HttpService);
            var response = await client.GetAsync($"{NacosRequestUrlConsts.ConfigUrl}{config.ToString()}");
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return new Result<T>(response.StatusCode, await response.Content.ReadAsStringAsync());
            }
            return new Result<T>(JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync()));
        }
    }
}
