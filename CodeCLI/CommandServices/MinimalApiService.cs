
using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;

namespace CodeCLI.CommandServices;

public class MinimalApiService : ClassService, ICommandService
{
    protected override string GetContent()
    {
        string name = "minimalApiTemp.txt";
        string content = ReadFile(name);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        string VarName = Name.ToCamelCase();
        content = content.Replace(nameof(VarName).ToVar(), VarName);
        return content;
    }
}
