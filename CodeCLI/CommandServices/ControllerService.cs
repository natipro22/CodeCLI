using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;

namespace CodeCLI.CommandServices;

public class ControllerService : ClassService, ICommandService
{
    private readonly string _templateName = "controllerTemp.txt";
    protected override string GetContent()
    {
        string content = ReadFile(_templateName);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        return content;
    }
}
