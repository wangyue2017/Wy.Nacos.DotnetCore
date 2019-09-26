using System;
using System.Collections.Generic;
using System.Text;

namespace Wy.Nacos.Configuration
{
    public class NacosCoreConfig
    {
        public NacosCoreConfig(string dataId, string group)
        {
            if (string.IsNullOrEmpty(dataId))
                throw new ArgumentNullException("dataId is null or empty");

            if (string.IsNullOrEmpty(group))
                throw new ArgumentNullException("group is null or empty");

            DataId = dataId;
            Group = group;
        }


        public NacosCoreConfig(string dataId, string group, string tenant) : this(dataId, group)
        {
            if (string.IsNullOrEmpty(tenant))
                throw new ArgumentNullException("tenant is null or empty");

            Tenant = tenant;
        }

        /// <summary>
        /// DataId
        /// </summary>
        public string DataId { set; get; } = string.Empty;

        /// <summary>
        /// 组
        /// </summary>
        public string Group { set; get; } = string.Empty;


        /// <summary>
        /// Nacos命名空间
        /// </summary>
        public string Tenant { set; get; } = string.Empty;


        public override string ToString()
        => string.IsNullOrEmpty(Tenant) ?
           $"?dataId={DataId}&group={Group}" : $"?dataId={DataId}&group={Group}&tenant={Tenant}";
    }
}
