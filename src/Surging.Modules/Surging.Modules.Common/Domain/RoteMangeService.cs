using Surging.Core.ProxyGenerator;
using Surging.IModuleServices.Common;
using Surging.IModuleServices.Common.Models;
using System.Threading.Tasks;

namespace Surging.Modules.Common.Domain
{
    public class RoteMangeService : ProxyServiceBase, IRoteMangeService
    {
        public Task<UserModel> GetServiceById(string serviceId)
        {
            return Task.FromResult(new UserModel());
        }

        public Task<bool> SetRote(RoteModel model)
        {
            return Task.FromResult(true);
        }
    }
}
