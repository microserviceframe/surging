using Microsoft.AspNetCore.Http;
using Surging.Core.CPlatform.Messages;

namespace Surging.Core.KestrelHttpServer.Filters.Implementation
{
    public class ActionExecutedContext
    {
        public HttpMessage Message { get; internal set; }
        public HttpContext Context { get; internal set; }
    }
}
