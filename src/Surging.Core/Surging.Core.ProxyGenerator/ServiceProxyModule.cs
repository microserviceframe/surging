using Autofac;
using Surging.Core.CPlatform;
using Surging.Core.CPlatform.Module;
using Surging.Core.ProxyGenerator.Diagnostics;
using Surging.Core.CPlatform.Diagnostics;

namespace Surging.Core.ProxyGenerator
{
    public class ServiceProxyModule : EnginePartModule
    {
        public override void Initialize(AppModuleContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            serviceProvider.GetInstances<IServiceProxyFactory>();
            if (AppConfig.ServerOptions.ReloadOnChange)
            {
                //new ServiceRouteWatch(serviceProvider,
                //        () =>
                //        {
                //            var builder = new ContainerBuilder();
                //            var result = serviceProvider.GetInstances<IServiceEngineBuilder>().ReBuild(builder);
                //            if (result != null)
                //            {
                //                builder.Update(serviceProvider.Current.ComponentRegistry);
                //                serviceProvider.GetInstances<IServiceEntryManager>().UpdateEntries(serviceProvider.GetInstances<IEnumerable<IServiceEntryProvider>>());
                //            //  serviceProvider.GetInstances<IServiceProxyFactory>().RegisterProxType(result.Value.Item2.ToArray(), result.Value.Item1.ToArray());
                //            serviceProvider.GetInstances<IServiceRouteProvider>().RegisterRoutes(0);
                //                serviceProvider.GetInstances<IServiceProxyFactory>();
                //            }
                //        });
            }
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder"></param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.RegisterType<RpcTransportDiagnosticProcessor>().As<ITracingDiagnosticProcessor>().SingleInstance();
        }
    }
}
