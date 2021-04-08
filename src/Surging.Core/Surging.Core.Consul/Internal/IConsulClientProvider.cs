using Consul;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Surging.Core.Consul.Internal
{
    public  interface IConsulClientProvider
    {
        ValueTask<ConsulClient> GetClient();

        ValueTask<IEnumerable<ConsulClient>> GetClients();

        ValueTask Check();
    }
}
