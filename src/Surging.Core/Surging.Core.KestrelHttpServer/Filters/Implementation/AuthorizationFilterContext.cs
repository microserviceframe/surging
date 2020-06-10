﻿using Microsoft.AspNetCore.Http;
using Surging.Core.CPlatform.Messages;
using Surging.Core.CPlatform.Routing;

namespace Surging.Core.KestrelHttpServer.Filters.Implementation
{
    public class AuthorizationFilterContext
    {
        public ServiceRoute Route { get; internal set; }

        public string Path { get; set; }

        public HttpResultMessage<object> Result { get; set; }

        public HttpContext Context { get; internal set; }
    }
}
