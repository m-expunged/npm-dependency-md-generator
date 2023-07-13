using System.Text.Json.Serialization;

namespace NpmDependencyVersions
{
    internal sealed class Repository
    {
        #region Properties

        [JsonPropertyName("type")]
        public string Type { get; set; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        #endregion Properties
    }
}
