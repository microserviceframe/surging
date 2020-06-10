using System.Collections.Generic;

namespace Surging.Core.Thrift.Runtime
{
    public interface IThriftServiceEntryProvider
    {
        List<ThriftServiceEntry> GetEntries();
    }
}
