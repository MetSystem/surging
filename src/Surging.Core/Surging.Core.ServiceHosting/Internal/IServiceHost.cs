using Autofac;
using System;

namespace Surging.Core.ServiceHosting.Internal
{
    /// <summary>
    /// 服务主机
    /// </summary>
    public interface IServiceHost : IDisposable
    {
        /// <summary>
        /// 运行
        /// </summary>
        IDisposable Run();

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns>IContainer</returns>
        IContainer Initialize();
    }
}
