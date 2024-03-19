using Code.Commands.Generate;
using Code.Common;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Code.CommandServices;

public abstract class CommandService : ICommandService
{

    public string Name { get; set; } = string.Empty;
    public string Directory { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string CreateFile()
    {
        if (!string.IsNullOrEmpty(Directory) && !System.IO.Directory.Exists(Directory))
        {
            System.IO.Directory.CreateDirectory(Directory);
        }
        FileName = string.IsNullOrEmpty(FileName) ? Name : FileName;
        File.WriteAllText(!string.IsNullOrEmpty(Directory) ? Directory + "/" + $"{FileName}.cs" : $"{FileName}.cs",
                          Regex.Replace(GetContent(), @" {2,}", " "));
        return $"{FileName}.cs";
    }
    protected abstract string GetContent();

    protected string ReadFile(string name)
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
