using CodeCLI.Commands.Generate;
using CodeCLI.Common;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CodeCLI.CommandServices;

public abstract class CommandService : ICommandService
{

    public string Name { get; set; } = string.Empty;
    public string Directory { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string Extension { get; set; } = "cs";

    public string CreateFile()
    {
        if (!string.IsNullOrEmpty(Directory) && !System.IO.Directory.Exists(Directory))
        {
            System.IO.Directory.CreateDirectory(Directory);
        }
        FileName = string.IsNullOrEmpty(FileName) ? Name : FileName;
        File.WriteAllText(!string.IsNullOrEmpty(Directory) ? Path.Combine(Directory, $"{FileName}.{Extension}") : $"{FileName}.{Extension}",
                          Regex.Replace(GetContent(), @" {2,}", " "));
        return $"{FileName}.{Extension}";
    }
    protected abstract string GetContent();

    public static string ReadFile(string name)
    {
        // Determine path
        var assembly = Assembly.GetEntryAssembly();
        if (!name.StartsWith(nameof(Program)))
        {
            name = assembly.GetManifestResourceNames()
                .First(str => str.EndsWith(name));
        }
        using (Stream stream = assembly.GetManifestResourceStream(name))
        using (StreamReader reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }

}
