using Microsoft.AspNet.SignalR;
using Orchard;

namespace NGM.SignalR {
    public interface IOrchardHubConfiguration : IDependency {
        string Path { get; }
        HubConfiguration ConnectionConfiguration { get; }
    }

    public class DefaultHubConfiguration : IOrchardHubConfiguration {
        private readonly IDependencyResolver _dependencyResolver;

        public DefaultHubConfiguration(IDependencyResolver dependencyResolver) {
            _dependencyResolver = dependencyResolver;
        }

        public string Path {
            get { return string.Empty; }
        }

        public HubConfiguration ConnectionConfiguration {
            get { return new HubConfiguration { Resolver = _dependencyResolver }; }
        }
    }
}