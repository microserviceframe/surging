using Surging.Core.ServiceHosting.Internal;
using System.Linq;
using Autofac;
using Surging.Core.CPlatform.Cache;
using Surging.Core.Caching.Configurations;

namespace Surging.Core.Caching
{
    public static class ServiceHostBuilderExtensions
    {
        public static IServiceHostBuilder UseServiceCache(this IServiceHostBuilder hostBuilder)
        {
            return hostBuilder.MapServices(mapper =>
            {
                var serviceCacheProvider = mapper.Resolve<ICacheNodeProvider>();
                var addressDescriptors = serviceCacheProvider.GetServiceCaches().ToList();
                mapper.Resolve<IServiceCacheManager>().SetCachesAsync(addressDescriptors);
                mapper.Resolve<IConfigurationWatchProvider>();
            });
        }

    }
}
