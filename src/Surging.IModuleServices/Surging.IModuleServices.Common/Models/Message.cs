using System.Collections.Generic;

namespace Surging.IModuleServices.Common.Models
{
    public class Message
    {
        public string RoutePath { get; set; }

        public string ServiceKey { get; set; }

        public IDictionary<string, object> Parameters { get; set; }
    }
}
