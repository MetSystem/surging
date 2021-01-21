using Greet;
using Grpc.Core;
using Surging.IModuleServices.Common;
using Surging.Modules.Common.Behaviors;
using System.Threading.Tasks;

namespace Surging.Modules.Common.Domain
{
    public class GreeterService : GreeterBehavior, IGreeterService
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
