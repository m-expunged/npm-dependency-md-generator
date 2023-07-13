using System.Text.Json.Serialization;

namespace NpmDependencyVersions
{
    internal sealed class Maintainer
    {
        #region Properties

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        #endregion Properties
    }
}
