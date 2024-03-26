using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;
using System.Text.RegularExpressions;

namespace CodeCLI.CommandServices;

public class EnumService : CommandService, ICommandService
{
    protected override string GetContent()
    {
        string name = "enumTemp.txt";
        string content = ReadFile(name);

        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        return content;
    }
}
