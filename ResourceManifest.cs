using Orchard.UI.Resources;

namespace NGM.OperationalTransformation {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var resourceManifest = builder.Add();
            resourceManifest.DefineScript("jQuery_SignalR").SetUrl("jquery.signalR-1.0.0.min.js", "jquery.signalR-1.0.0.js").SetVersion("1.0.0").SetDependencies("jQuery");
            resourceManifest.DefineScript("jQuery_SignalR_Hubs").SetUrl("~/signalr/hubs").SetDependencies("jQuery_SignalR");
        }
    }
}