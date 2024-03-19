
using Code.Common;
using Code.DirectoryNamespace;

namespace Code.CommandServices;

public class ValidatorService : ClassService, ICommandService
{
    protected override string GetContent()
    {
        string name = "validatorTemp.txt";
        string content = ReadFile(name);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        return content;
    }
}
