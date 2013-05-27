using Autofac;
using Microsoft.AspNet.SignalR;
using NGM.SignalR.Autofac.Modules.Sources;
using Module = Autofac.Module;

namespace NGM.SignalR.Autofac.Modules
{
    public class DependencyResolverModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder
                .RegisterType<AutofacDependencyResolver>()
                .As<IDependencyResolver>()
                .InstancePerMatchingLifetimeScope("shell");

            //builder.RegisterHubs(Assembly.GetExecutingAssembly());

            builder.RegisterSource(new HubsSource());
        }
    }
}