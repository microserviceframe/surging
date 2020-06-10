﻿using Microsoft.AspNetCore.Http;
using Surging.Core.CPlatform.Messages;

namespace Surging.Core.KestrelHttpServer
{
    public class ActionContext
    {
        public ActionContext()
        {

        }

        public HttpContext HttpContext { get; set; }

        public TransportMessage Message { get; set; }

    }
}
