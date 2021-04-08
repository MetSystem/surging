using Surging.Core.Protocol.Tcp.Runtime;
using Surging.IModuleServices.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Surging.Modules.Common.Domain
{
    public class TcpService : TcpBehavior, ITcpService
    {
        public override async Task<bool> Dispatch(IEnumerable<byte> bytes)
        {
            await this.GetService<IMediaService>().Push(bytes);
            return await Task.FromResult(true);
        }
    }
}
