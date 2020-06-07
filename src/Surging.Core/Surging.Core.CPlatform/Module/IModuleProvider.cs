using System.Collections.Generic;

namespace Surging.Core.CPlatform.Module
{
	public interface IModuleProvider
    {
        List<AbstractModule> Modules { get; }

        string[] VirtualPaths { get; }

        void Initialize();
    }
}
