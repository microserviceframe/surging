using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;

namespace Surging.Core.ProxyGenerator.Interceptors.Implementation.Metadatas
{
	[AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public abstract  class ServiceIntercept : ServiceDescriptorAttribute
    {
        protected abstract string MetadataId { get; set; }
    }
}
