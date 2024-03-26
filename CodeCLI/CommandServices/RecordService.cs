using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;
using System.Text.RegularExpressions;

namespace CodeCLI.CommandServices;

public class RecordService : ClassService, ICommandService
{
    protected override string GetContent()
    {
        string name = "recordTemp.txt";
        string content = ReadFile(name);
        content = content.Replace(nameof(IsAbstract).ToVar(), IsAbstract ? "abstract" : string.Empty);
        content = content.Replace(nameof(IsSeald).ToVar(), IsSeald ? "seald" : string.Empty);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        string Inheritance = string.Empty;
        if (!string.IsNullOrEmpty(Extends) || Implements.Any())
        {
            Inheritance += " : ";
            Inheritance += Extends?.Trim() ?? string.Empty;
            if (!string.IsNullOrEmpty(Extends) && Implements.Any())
                Inheritance += ", ";
            Inheritance += string.Join(", ", Implements).Trim();
        }
        content = content.Replace(nameof(Inheritance).ToVar(), Inheritance);
        return content;
    }
}
