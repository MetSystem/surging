using Surging.Core.CPlatform.Utilities;
using System.Collections.Generic;

namespace Surging.Core.CPlatform.Module
{
    public class AppModuleContext
    {
        public AppModuleContext(List<AbstractModule> modules, 
            string[] virtualPaths,
            CPlatformContainer serviceProvoider)
        { 
            Modules = Check.NotNull(modules, nameof(modules));
            VirtualPaths = Check.NotNull(virtualPaths, nameof(virtualPaths));
            ServiceProvoider = Check.NotNull(serviceProvoider, nameof(serviceProvoider));
        }

        public List<AbstractModule> Modules { get; }

        public string[] VirtualPaths { get; }

        public CPlatformContainer ServiceProvoider { get; }
    }
}
