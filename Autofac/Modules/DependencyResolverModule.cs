using Autofac;
using Microsoft.AspNet.SignalR;
using NGM.SignalR.Autofac.Modules.Sources;

namespace NGM.SignalR.Autofac.Modules
{
    public class DependencyResolverModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder
                .RegisterType<AutofacDependencyResolver>()
                .As<IDependencyResolver>()
                .InstancePerDependency();

            builder.RegisterSource(new HubsSource());
        }
    }
}