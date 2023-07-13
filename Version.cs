using System.Text.Json.Serialization;

namespace NpmDependencyVersions
{
    internal sealed class Version
    {
        #region Properties

        [JsonPropertyName("version")]
        public string Number { get; set; } = null!;

        [JsonPropertyName("peerDependencies")]
        public Dictionary<string, string> PeerDependencies { get; set; } = new();

        [JsonPropertyName("dependencies")]
        public Dictionary<string, string> Dependencies { get; set; } = new();

        [JsonPropertyName("_id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("_nodeVersion")]
        public string NodeVersion { get; set; } = null!;

        [JsonPropertyName("_npmVersion")]
        public string NpmVersion { get; set; } = null!;

        #endregion Properties
    }
}
