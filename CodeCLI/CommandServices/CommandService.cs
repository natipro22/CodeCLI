using CodeCLI.Common;
using Humanizer;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CodeCLI.CommandServices;

public abstract class CommandService : ICommandService
{
    private string _name = string.Empty;
    public string Name { get => _name; set => _name = value.Pascalize(); }
    public string Directory { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string Extension { get; set; } = "cs";

    public string CreateFile()
    {
        Directory = string.IsNullOrEmpty(Directory)
            ? Path.GetDirectoryName(Name)?.ToPascalCase()
            ?? string.Empty : Directory.ToPascalCase();

        Name = Path.GetFileName(Name);

        if (!string.IsNullOrEmpty(Directory) && !System.IO.Directory.Exists(Directory))
        {
            System.IO.Directory.CreateDirectory(Directory);
        }

        FileName = string.IsNullOrEmpty(FileName) ? Name : FileName;
        File.WriteAllText(!string.IsNullOrEmpty(Directory) ? Path.Combine(Directory, $"{FileName.Pascalize()}.{Extension}") : $"{FileName.Pascalize()}.{Extension}",
                          Regex.Replace(GetContent(), @" {2,}", " "));

        return $"{FileName.Pascalize()}.{Extension}";
    }
    protected abstract string GetContent();

    public static string ReadFile(string name)
    {
        // Determine path
        var assembly = Assembly.GetExecutingAssembly();
        if (!name.StartsWith(nameof(Program)))
        {
            name = assembly.GetManifestResourceNames()
                .First(str => str.EndsWith(name));
        }
        using (Stream? stream = assembly.GetManifestResourceStream(name))
        {
            if (stream is not null)
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            else
            {
                throw new FileNotFoundException("Resource file not found!.");
            }
        }
    }

}
