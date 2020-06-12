namespace Surging.Core.CPlatform.Engines.Implementation
{
    /// <summary>
    /// 服务引擎虚拟路径
    /// </summary>
    public abstract class VirtualPathProviderServiceEngine : IServiceEngine
    {
        /// <summary>
        /// 模块服务路径集合
        /// </summary>
        public string[] ModuleServiceLocationFormats { get; set; }

        /// <summary>
        /// 组件模块服务路径集合
        /// </summary>
        public string[] ComponentServiceLocationFormats { get; set; }
    }
}
