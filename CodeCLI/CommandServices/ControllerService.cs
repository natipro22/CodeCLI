using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;

namespace CodeCLI.CommandServices;

public class ControllerService : ClassService, ICommandService
{
    protected override string GetContent()
    {
        string name = "controllerTemp.txt";
        string content = ReadFile(name);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        return content;
    }
}
