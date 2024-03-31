
using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;

namespace CodeCLI.CommandServices;

public class ValidatorService : ClassService, ICommandService
{
    private readonly string _templateName = "validatorTemp.txt";
    protected override string GetContent()
    {
        string content = ReadFile(_templateName);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        return content;
    }
}
