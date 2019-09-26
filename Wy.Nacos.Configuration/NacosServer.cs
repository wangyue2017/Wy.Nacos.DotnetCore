using System;
using System.Collections.Generic;
using System.Text;

namespace Wy.Nacos.Configuration
{

    /// <summary>
    /// Nacos注册参数
    /// </summary>
   public class NacosServer
    {

        /// <summary>
        /// 请求服务的地址(负载均衡暴露地址)
        /// </summary>
        public string ServerAddress { set; get; }


        /// <summary>
        /// 服务注册IP（选填 默认本机IP 本地多网卡的情况下实例可能存在问题）
        /// </summary>
        public string Loaction { set; get; }


        /// <summary>
        /// 服务注册端口
        /// </summary>
        public int Port { set; get; } = 5555;
    }
}
