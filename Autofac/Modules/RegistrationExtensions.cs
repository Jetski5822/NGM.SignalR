using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Features.Scanning;
using Microsoft.AspNet.SignalR.Hubs;

namespace NGM.SignalR.Autofac.Modules {
    /// <summary>
    /// Extends <see cref="ContainerBuilder"/> with methods to support ASP.NET SignalR.
    /// </summary>
    public static class RegistrationExtensions {
        /// <summary>
        /// Register types that implement <see cref="IHub"/> in the provided assemblies.
        /// </summary>
        /// <param name="builder">The container builder.</param>
        /// <param name="controllerAssemblies">Assemblies to scan for controllers.</param>
        /// <returns>Registration builder allowing the controller components to be customised.</returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle>
            RegisterHubs(this ContainerBuilder builder, params Assembly[] controllerAssemblies) {
            return builder.RegisterAssemblyTypes(controllerAssemblies)
                .Where(t => typeof(IHub).IsAssignableFrom(t))
                .ExternallyOwned();
        }
    }
}