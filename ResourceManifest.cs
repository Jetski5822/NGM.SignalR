using Orchard.UI.Resources;

namespace NGM.SignalR {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var resourceManifest = builder.Add();
            resourceManifest.DefineScript("jQuery_SignalR").SetUrl("jquery.signalR-1.1.1.min.js", "jquery.signalR-1.1.1.js").SetVersion("1.1.1").SetDependencies("jQuery");
            resourceManifest.DefineScript("jQuery_SignalR_Hubs").SetUrl("~/signalr/hubs").SetDependencies("jQuery_SignalR");
        }
    }
}