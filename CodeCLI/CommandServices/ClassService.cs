using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;

namespace CodeCLI.CommandServices;

public class ClassService : CommandService, ICommandService
{
    private readonly string _templateName = "classTemp.txt";
    public string Extends { get; set; }
    public IEnumerable<string> Implements { get; set; }
    public bool IsAbstract { get; set; }
    public bool IsSeald { get; set; }

    protected override string GetContent()
    {
        string content = ReadFile(_templateName);

        content = content.Replace(nameof(IsAbstract).ToVar(), IsAbstract ? "abstract" : string.Empty);
        content = content.Replace(nameof(IsSeald).ToVar(), IsSeald ? "sealed" : string.Empty);
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
