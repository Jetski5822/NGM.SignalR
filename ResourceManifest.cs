using Orchard.UI.Resources;

namespace NGM.SignalR {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var resourceManifest = builder.Add();
            resourceManifest.DefineScript("jQuery_SignalR").SetUrl("jquery.signalR-2.0.1.min.js", "jquery.signalR-2.0.1.js").SetVersion("2.0.1").SetDependencies("jQuery");
            resourceManifest.DefineScript("jQuery_SignalR_Hubs").SetUrl("~/signalr/hubs").SetDependencies("jQuery_SignalR");
        }
    }
}