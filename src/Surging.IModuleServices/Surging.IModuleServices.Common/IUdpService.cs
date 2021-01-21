using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace Surging.IModuleServices.Common
{
    [ServiceBundle("Udp/{Service}")]
    public interface IUdpService : IServiceKey
    {
    }
}
