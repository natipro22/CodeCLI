
using Code.Common;
using Code.DirectoryNamespace;

namespace Code.CommandServices;

public class HandlerService : ClassService, ICommandService
{
    public string Response { get; set; } = string.Empty;
    
    protected override string GetContent()
    {
        string name = "handlerTemp.txt";
        string content = ReadFile(name);
        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);
        content = content.Replace(nameof(Response).ToVar(), Response);
        return content;
    }
}
