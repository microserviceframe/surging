using System;

namespace Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes
{
    /// <summary>
    /// 服务集标记。
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class ServiceBundleAttribute : Attribute
    {
        public ServiceBundleAttribute(string routeTemplate, bool isPrefix = true)
        {
            RouteTemplate = routeTemplate;
            IsPrefix = isPrefix;
        }

        /// <summary>
        /// 路由模板
        /// </summary>
        public string RouteTemplate { get; }

        /// <summary>
        /// 是否作为前缀
        /// </summary>
        public bool IsPrefix { get; }
    }
}