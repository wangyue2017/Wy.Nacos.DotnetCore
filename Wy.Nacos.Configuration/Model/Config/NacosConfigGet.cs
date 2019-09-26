using System;
using System.Collections.Generic;
using System.Text;

namespace Wy.Nacos.Configuration.Model.Config
{
    public class NacosConfigGet : NacosCoreConfig
    {

        public NacosConfigGet(string dataId, string group) : base(dataId, group)
        {

        }


        public NacosConfigGet(string dataId, string group, string tenant) : base(dataId, group, tenant)
        { 
        
        }
    }
}
