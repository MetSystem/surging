using Surging.Core.CPlatform.Module;

namespace Surging.Core.Common
{
    public class CommonModule : SystemModule
    {
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }

        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
        }
    }
}
