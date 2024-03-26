using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;

namespace CodeCLI.CommandServices.MediatR;

public class RequestService : RecordService, ICommandService
{
    private readonly string _templateName = "requestTemp.txt";

    public CQRS Type { get; set; }

    public string Response { get; set; } = string.Empty;

    protected override string GetContent()
    {
        string content = ReadFile(_templateName);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        content = content.Replace(nameof(Response).ToVar(), Response);
        content = content.Replace(nameof(Type).ToVar(), Type.ToString());
        return content;
    }
}
