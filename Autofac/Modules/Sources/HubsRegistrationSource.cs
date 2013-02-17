// Contribution : Piotr Szymd
// https://bitbucket.org/Proligence/proligence.signalr/wiki/Home
// Registers hubs within Orchard.

using System;
using System.Collections.Generic;
using Autofac.Builder;
using Autofac.Core;
using Microsoft.AspNet.SignalR.Hubs;

namespace NGM.SignalR.Autofac.Modules.Sources
{
    public class HubsSource : IRegistrationSource
    {
        public bool IsAdapterForIndividualComponents
        {
            get { return false; }
        }

        public IEnumerable<IComponentRegistration> RegistrationsFor(Service service, Func<Service, IEnumerable<IComponentRegistration>> registrationAccessor)
        {
            var serviceWithType = service as IServiceWithType;
            if (serviceWithType == null)
                yield break;

            var serviceType = serviceWithType.ServiceType;
            if (!typeof(IHub).IsAssignableFrom(serviceType))
                yield break;

            var rb = RegistrationBuilder
                .ForType(serviceType)
                .As(typeof (IHub), serviceType)
                .InstancePerDependency();

            yield return rb.CreateRegistration();
        }
    }
}