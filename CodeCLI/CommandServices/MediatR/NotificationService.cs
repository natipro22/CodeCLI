using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;

namespace CodeCLI.CommandServices.MediatR;
public class NotificationService : CommandService
{
    protected override string GetContent()
    {
        string name = "notificationTemp.txt";
        string content = ReadFile(name);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        return content;
    }
}
