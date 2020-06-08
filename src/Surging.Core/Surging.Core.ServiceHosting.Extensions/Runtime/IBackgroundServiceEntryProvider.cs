using System.Collections.Generic;

namespace Surging.Core.ServiceHosting.Extensions.Runtime
{
    public interface IBackgroundServiceEntryProvider
    {
        IEnumerable<BackgroundServiceEntry> GetEntries();
    }
}
