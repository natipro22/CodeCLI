using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;

namespace CodeCLI.CommandServices;

public class InterfaceService : CommandService, ICommandService
{
    private readonly string _templateName = "interfaceTemp.txt";
    public IEnumerable<string> Extends { get; set; }
    public char Prefix { get; set; } = 'I';

    protected override string GetContent()
    {
        string content = ReadFile(_templateName);

        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), $"{(Prefix.Equals(' ') ? string.Empty : Prefix)}{Name}");
        string Inheritance = string.Empty;
        if (Extends.Any())
        {
            Inheritance += " : ";
            Inheritance += string.Join(", ", Extends).Trim();
        }
        content = content.Replace(nameof(Inheritance).ToVar(), Inheritance);
        return content;
    }
}
