using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Wy.Nacos.Configuration;

namespace Wy.Nacos.Core
{
    public static class NacosServiceCollectionExtensions
    {
        public static void AddNacos(this IServiceCollection services, Action<NacosServer> configure)
        {
            var _configure = new NacosServer();
            configure?.Invoke(_configure);

            if (string.IsNullOrEmpty(_configure.ServerAddress))
                throw new ArgumentNullException($"ServerAddress参数未配置,示例:http://127.0.0.1:8848,Nacos地址(尽量采用内网访问地址)");
           
            if (string.IsNullOrEmpty(_configure.Loaction))
                throw new ArgumentNullException($"服务注册IP参数未配置,示例:127.0.0.1,确保Port属性匹配");

            services.AddHttpContextAccessor();

            services.AddHttpClient(NacosHttpConsts.HttpService,client=> 
            {
                client.BaseAddress = new Uri(_configure.ServerAddress);
            });

            services.AddScoped<INacosConfigApi, NacosConfigApi>();
        }
    }
}
