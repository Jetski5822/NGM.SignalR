using System.Collections.Generic;
using System.Web.Routing;
using Orchard.Mvc.Routes;
using Owin;

namespace NGM.SignalR.Routes {
    public class HubRouteProvider : IRouteProvider {
        private readonly IOrchardHubConfiguration _orchardHubConfiguration;

        public HubRouteProvider(IOrchardHubConfiguration orchardHubConfiguration) {
            _orchardHubConfiguration = orchardHubConfiguration;
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            var mapOwinRoute = new RouteCollection().MapOwinPath("signalr.hubs", "/signalr", map => {
                    map.MapHubs(_orchardHubConfiguration.Path, _orchardHubConfiguration.ConnectionConfiguration);
                });

            yield return new RouteDescriptor {
                Route = mapOwinRoute,
                Priority = int.MaxValue
            };
        }
    }
}