using Autofac;
using Microsoft.Extensions.Logging;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Module;
using Surging.Core.CPlatform.Runtime.Server;
using Surging.Core.CPlatform.Transport.Codec;
using Surging.Core.Protocol.Tcp.Runtime;
using Surging.Core.Protocol.Tcp.Runtime.Implementation;

namespace Surging.Core.Protocol.Tcp
{
    public class TcpProtocolModule : EnginePartModule
    {
        public override void Initialize(AppModuleContext serviceProvider)
        {
            base.Initialize(serviceProvider);
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.Register(provider =>
            {
                return new DefaultTcpServiceEntryProvider(
                       provider.Resolve<IServiceEntryProvider>(),
                    provider.Resolve<ILogger<DefaultTcpServiceEntryProvider>>(),
                      provider.Resolve<CPlatformContainer>()
                      );
            }).As(typeof(ITcpServiceEntryProvider)).SingleInstance();
            builder.RegisterType(typeof(TcpServiceExecutor)).As(typeof(IServiceExecutor))
            .Named<IServiceExecutor>(CommunicationProtocol.Udp.ToString()).SingleInstance();
            if (CPlatform.AppConfig.ServerOptions.Protocol == CommunicationProtocol.Dns)
            {
                RegisterDefaultProtocol(builder);
            }
            else if (CPlatform.AppConfig.ServerOptions.Protocol == CommunicationProtocol.None)
            {
                RegisterTcpProtocol(builder);
            }
        }

        private static void RegisterDefaultProtocol(ContainerBuilderWrapper builder)
        {
            builder.Register(provider =>
            {
                return new DotNettyTcpServerMessageListener(provider.Resolve<ILogger<DotNettyTcpServerMessageListener>>(),
                      provider.Resolve<ITransportMessageCodecFactory>()
                      );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Tcp.ToString());
                var messageListener = provider.Resolve<DotNettyTcpServerMessageListener>();
                return new TcpServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);

            }).As<IServiceHost>();
        }

        private static void RegisterTcpProtocol(ContainerBuilderWrapper builder)
        {

            builder.Register(provider =>
            {
                return new DotNettyTcpServerMessageListener(provider.Resolve<ILogger<DotNettyTcpServerMessageListener>>(),
                      provider.Resolve<ITransportMessageCodecFactory>()
                      );
            }).SingleInstance();
            builder.Register(provider =>
            {
                var serviceExecutor = provider.ResolveKeyed<IServiceExecutor>(CommunicationProtocol.Tcp.ToString());
                var messageListener = provider.Resolve<DotNettyTcpServerMessageListener>();
                return new TcpServiceHost(async endPoint =>
                {
                    await messageListener.StartAsync(endPoint);
                    return messageListener;
                }, serviceExecutor);

            }).As<IServiceHost>();
        }
    }
}
