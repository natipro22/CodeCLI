using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;
using Humanizer;

namespace CodeCLI.CommandServices.Carter;
internal class EndpointService : CommandService
{
    private readonly string _templateName = "CarterTemp.txt";
    private string PlularName { get => Name.Pluralize(); }

    protected string RequestType { get; private set; }
    protected override string GetContent()
    {
        string content = ReadFile(_templateName);
        //if (Name.StartsWith("Get"))
        //{
        //    RequestType = $"{Name}Query";
        //}
        //else if (Name.StartsWith("Create") || Name.StartsWith("Update"))
        //{
        //    RequestType = $"{Name}Command";
        //}
        //else
        //{
        //    RequestType = "object";
        //}
        
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        content = content.Replace(nameof(PlularName).ToVar(), PlularName);
        //content = content.Replace(nameof(RequestType).ToVar(), RequestType);
        return content;
    }
}
