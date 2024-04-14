using System.IO;
using System.Text.Json;
using build.Utils;

namespace build;

public class ProjectBuildSettings
{
    public required string[] References { get; set; }
    public required string[] AssetBundles { get; set; }
    public required string ProjectFile { get; set; }
    public required string UnityDir { get; set; }
    public required string ManifestAuthor { get; set; }
    public required string NetcodePatcherRelease { get; set; }
    public required string LethalEmotesApiVersion { get; set; }

    public static ProjectBuildSettings? LoadFromFile(AbsolutePath filePath)
    {
        return JsonSerializer.Deserialize<ProjectBuildSettings>(File.ReadAllText(filePath));
    }
}