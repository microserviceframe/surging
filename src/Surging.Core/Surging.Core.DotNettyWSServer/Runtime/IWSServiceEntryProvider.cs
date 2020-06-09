using System.Collections.Generic;

namespace Surging.Core.DotNettyWSServer.Runtime
{
    public interface IWSServiceEntryProvider
    {
        IEnumerable<WSServiceEntry> GetEntries();
    }
}
