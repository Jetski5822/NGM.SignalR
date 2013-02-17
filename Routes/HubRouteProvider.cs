using System.Collections.Generic;
using System.Web.Routing;
using Microsoft.Owin.Host.SystemWeb;
using NGM.SignalR.Middleware;
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
            yield return new RouteDescriptor {
                Route = new RouteCollection().MapOwinRoute("signalr.hubs", "/signalr", map => {
                        map.Use(typeof (WorkLifetimeScopeHandler));
                        map.MapHubs(_orchardHubConfiguration.Path, _orchardHubConfiguration.ConnectionConfiguration);
                    }),
                Priority = int.MaxValue
            };
        }
    }
}