using Surging.Core.CPlatform.Ioc;
using System;

namespace Surging.Core.Grpc.Runtime
{
    public class GrpcServiceEntry
    {
        public Type Type { get; set; }

        public IServiceBehavior Behavior { get; set; }
    }
}
