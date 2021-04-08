using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Surging.Core.ServiceHosting.Internal
{
    /// <summary>
    /// 服务主机建造者接口
    /// </summary>
    public  interface IServiceHostBuilder
    {
        /// <summary>
        /// 建造
        /// </summary>
        /// <returns>服务主机</returns>
        IServiceHost Build();

        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="builder">建造者</param>
        /// <returns>IServiceHostBuilder</returns>
        IServiceHostBuilder RegisterServices(Action<ContainerBuilder> builder);

        /// <summary>
        /// 配置日志
        /// </summary>
        /// <param name="configure">configure</param>
        /// <returns>IServiceHostBuilder</returns>

        IServiceHostBuilder ConfigureLogging(Action<ILoggingBuilder> configure);

        /// <summary>
        /// 配置服务
        /// </summary>
        /// <param name="configureServices">配置服务</param>
        /// <returns>IServiceHostBuilder</returns>

        IServiceHostBuilder ConfigureServices(Action<IServiceCollection> configureServices);

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="builder">建造者</param>
        /// <returns>IServiceHostBuilder</returns>
        IServiceHostBuilder Configure(Action<IConfigurationBuilder> builder);

        /// <summary>
        /// 映射服务
        /// </summary>
        /// <param name="mapper">映射</param>
        /// <returns>IServiceHostBuilder</returns>
        IServiceHostBuilder MapServices(Action<IContainer> mapper);
         
    }
}
