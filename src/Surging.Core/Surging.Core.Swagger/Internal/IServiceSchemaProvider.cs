using System.Collections.Generic;

namespace Surging.Core.Swagger.Internal
{
    public interface IServiceSchemaProvider
    {
        IEnumerable<string> GetSchemaFilesPath();
    }
}
