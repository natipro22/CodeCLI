using CliFx.Infrastructure;
using Humanizer;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace CodeCLI.Common;

public static class CommandsExtension
{
    public static void FileCreated(this IConsole console, string name)
        => console.Output.WriteLine($"{name} created successfully.");
    public static string ToPascalCase(this string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }
        string[] directories = Directory.GetDirectories(name);

        var pascalizeDirectory = directories.Select(d => d.Pascalize());

        return string.Join("/", pascalizeDirectory);
    }

    public static string ToCamelCase(this string name)
        => Regex.Replace(name, @"^.", m => m.Value.ToLowerInvariant());

    public static string ToVar(this object obj)
    {
        return $"@{nameof(obj)}";
    }

    public static string ToVar(this string name)
    {
        return $"@{name}";
    }

    public static string GetFileDirectory(this string pattern, string? parent = null)
    {
        var directory = parent ?? Directory.GetCurrentDirectory();

        string[] csprojFiles = Directory.GetFiles(directory, pattern);

        if (csprojFiles.Length > 0)
            return directory;
        string parentDirectory = Directory.GetParent(directory)?.FullName!;
        if (parentDirectory is not null && parentDirectory != directory)
        {
            return pattern.GetFileDirectory(parentDirectory);
        }

        throw new FileNotFoundException($"no {pattern} file found!.");
    }

    public static void Replace(this string fileName, string path, string pattern, string replacement, string? usings = null)
    {
        string content = File.ReadAllText(path);

        // Perform the replacement
        string buildModifiedContent = Regex.Replace(content, pattern, replacement);

        // Write the modified content back to the file
        File.WriteAllText(path, $"{usings ??= string.Empty}\n{buildModifiedContent}");
    }
}
