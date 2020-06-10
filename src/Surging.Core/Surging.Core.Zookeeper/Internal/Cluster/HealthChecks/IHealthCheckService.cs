﻿using Surging.Core.CPlatform.Address;
using System.Threading.Tasks;

namespace Surging.Core.Zookeeper.Internal.Cluster.HealthChecks
{
    public interface IHealthCheckService
    {
        void Monitor(AddressModel address);

        ValueTask<bool> IsHealth(AddressModel address);
    }
}
