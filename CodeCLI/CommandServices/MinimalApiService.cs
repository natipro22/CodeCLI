
using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;
using Humanizer;

namespace CodeCLI.CommandServices;

public class MinimalApiService : ClassService, ICommandService
{
    private string PlularName { get => Name.Pluralize(); }
    private string VarName { get => Name.Camelize(); }
    protected override string GetContent()
    {
        string name = "minimalApiTemp.txt";
        string content = ReadFile(name);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        content = content.Replace(nameof(VarName).ToVar(), VarName);
        content = content.Replace(nameof(PlularName).ToVar(), PlularName);
        return content;
    }
}
