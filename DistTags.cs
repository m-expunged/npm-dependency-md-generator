using System.Text.Json.Serialization;

namespace NpmDependencyVersions
{
    internal sealed class DistTags
    {
        #region Properties

        [JsonPropertyName("latest")]
        public string Latest { get; set; } = null!;

        #endregion Properties
    }
}
