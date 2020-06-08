using System.Collections.Generic;

namespace Surging.Core.Grpc.Runtime
{
	public interface IGrpcServiceEntryProvider
    {
        List<GrpcServiceEntry> GetEntries();
    }
}
