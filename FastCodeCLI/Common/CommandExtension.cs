using CliFx.Infrastructure;
using System.Text.RegularExpressions;

namespace Code.Common;

public static class CommandsExtension
{
    public static void FileCreated(this IConsole console, string name)
        => console.Output.WriteLine($"{name} created successfully.");
    public static string ToPascalCase(this string name)
        => Regex.Replace(name, "(?:^|-|_)([a-z])", m => m.Groups[1].Value.ToUpper());

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
}
