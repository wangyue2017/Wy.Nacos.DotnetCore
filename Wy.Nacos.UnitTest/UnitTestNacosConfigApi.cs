using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wy.Nacos.Configuration;
using Wy.Nacos.Core;

namespace Wy.Nacos.UnitTest
{
    [TestClass]
    public class UnitTestNacosConfigApi
    {
        [TestMethod]
        public async Task GetConfigApi()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddNacos(options =>
            {
                options.ServerAddress = "http://106.12.21.43:8848";
                options.Loaction = "127.0.0.1";
            });

            var provider = services.BuildServiceProvider();

            var api = provider.GetService<INacosConfigApi>();

            var result = await api.GetAsync(new NacosConfig("001", "group_001"));

        }
    }
}
