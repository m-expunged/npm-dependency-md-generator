using System.Text.Json.Serialization;

namespace NpmDependencyVersions
{
    internal sealed class Author
    {
        #region Properties

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        #endregion Properties
    }
}
