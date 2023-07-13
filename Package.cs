using System.Text.Json.Serialization;

namespace NpmDependencyVersions
{
    internal sealed class Package
    {
        #region Properties

        [JsonPropertyName("_id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("_rev")]
        public string Rev { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; set; } = null!;

        [JsonPropertyName("homepage")]
        public string Homepage { get; set; } = null!;

        [JsonPropertyName("distTags")]
        public DistTags DistTags { get; set; } = null!;

        [JsonPropertyName("versions")]
        public Dictionary<string, Version> Versions { get; set; } = new()!;

        [JsonPropertyName("time")]
        public Dictionary<string, DateTimeOffset> Time { get; set; } = new()!;

        [JsonPropertyName("author")]
        public Author Author { get; set; } = null!;

        [JsonPropertyName("repository")]
        public Repository Repository { get; set; } = null!;

        [JsonPropertyName("readme")]
        public string Readme { get; set; } = null!;

        [JsonPropertyName("keywords")]
        public List<string> Keywords { get; set; } = null!;

        [JsonPropertyName("license")]
        public string License { get; set; } = null!;

        #endregion Properties
    }
}
