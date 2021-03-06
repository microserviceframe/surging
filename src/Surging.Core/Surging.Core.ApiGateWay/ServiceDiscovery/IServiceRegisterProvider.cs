﻿using Surging.Core.ApiGateWay.ServiceDiscovery.Implementation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Surging.Core.ApiGateWay.ServiceDiscovery
{
    public interface IServiceRegisterProvider
    {
        Task<IEnumerable<ServiceAddressModel>> GetAddressAsync(string condition = null);
    }
}
