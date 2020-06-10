using Microsoft.Extensions.Configuration;
using Surging.Core.DNS.Configurations;

namespace Surging.Core.DNS
{
    public static class AppConfig
    {
        public static IConfigurationRoot Configuration { get; set; }

        public static DnsOption DnsOption { get; set; }
    }
}
