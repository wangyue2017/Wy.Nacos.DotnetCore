using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wy.Nacos.Configuration;

namespace Wy.Nacos.Core
{
    public interface INacosConfigApi
    {
        Task<Result<string>> GetAsync(NacosCoreConfig config);

        Task<Result<T>> GetAsync<T>(NacosCoreConfig config);
    }
}
