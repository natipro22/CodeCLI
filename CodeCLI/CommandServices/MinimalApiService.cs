
using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;
using Humanizer;

namespace CodeCLI.CommandServices;

public class MinimalApiService : ClassService, ICommandService
{
    private readonly string _templateName = "minimalApiTemp.txt";
    private string PlularName { get => Name.Pluralize(); }
    private string VarName { get => Name.Camelize(); }
    protected override string GetContent()
    {
        string content = ReadFile(_templateName);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        content = content.Replace(nameof(VarName).ToVar(), VarName);
        content = content.Replace(nameof(PlularName).ToVar(), PlularName);
        return content;
    }
}
