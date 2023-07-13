using NpmDependencyVersions;
using System.Net.Http.Json;
using System.Text;

try
{
    var packageName = args[0];
    var outputDir = args[1];

    Console.WriteLine($"Package name: {packageName}");
    Console.WriteLine($"Output directory: {outputDir}");

    var url = $"https://registry.npmjs.org/{packageName}";
    var client = new HttpClient();
    var package = await client.GetFromJsonAsync<Package>(url) ?? throw new Exception("The registry api did not return data");

    var dependencies = package.Versions.SelectMany(version => version.Value.Dependencies.Select(dep => new { dep.Key, Peer = false }).Concat(version.Value.PeerDependencies.Select(dep => new { dep.Key, Peer = true })));
    var dependencyColumns = dependencies.DistinctBy(dep => dep.Key).OrderBy(dep => dep.Key).ToArray();
    var columns = new[] { "Name", "Version", "Created", "Node Version", "Npm Version" }.Concat(dependencyColumns.Select(dep => dep.Peer ? $"(P) {dep.Key}" : dep.Key)).ToArray();

    var sb = new StringBuilder();

    sb.Append($"# {package.Name}\n\n");
    sb.AppendLine(BuildLine(columns));
    sb.AppendLine(BuildHeaderSpacer(columns));

    foreach (var version in package.Versions)
    {
        var dependencyVersions = dependencyColumns
            .Select(col => version.Value.Dependencies.Concat(version.Value.PeerDependencies).FirstOrDefault(dep => dep.Key == col.Key).Value)
            .ToArray();

        var created = package.Time.FirstOrDefault(x => x.Key == version.Key).Value;

        sb.AppendLine(BuildLine(new[] { version.Value.Id, version.Key, created.ToString(), version.Value.NodeVersion, version.Value.NpmVersion }.Concat(dependencyVersions).ToArray()));
    }

    Directory.CreateDirectory(outputDir);

    File.WriteAllText($"{Path.Combine(outputDir, "version")}.md", sb.ToString());

    Console.WriteLine("\nDone");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static string BuildLine(string[] values)
{
    return values.Aggregate(string.Empty, (current, next) => $"{current} | {next}").Trim() + " |";
}

static string BuildHeaderSpacer(params string[] columns)
{
    var spacers = columns.Select(c => string.Concat(Enumerable.Repeat('-', c.Length))).ToArray();
    return BuildLine(spacers);
}
