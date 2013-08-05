using Orchard.UI.Resources;

namespace NGM.SignalR {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var resourceManifest = builder.Add();
            resourceManifest.DefineScript("jQuery_SignalR").SetUrl("jquery.signalR-1.1.2.min.js", "jquery.signalR-1.1.2.js").SetVersion("1.1.2").SetDependencies("jQuery");
            resourceManifest.DefineScript("jQuery_SignalR_Hubs").SetUrl("~/signalr/hubs").SetDependencies("jQuery_SignalR");
        }
    }
}