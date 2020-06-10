using Surging.Core.CPlatform.Ioc;
using System;

namespace Surging.Core.Thrift.Runtime
{
    public class ThriftServiceEntry
    {
        public Type Type { get; set; }

        public IServiceBehavior Behavior { get; set; }
    }
}
