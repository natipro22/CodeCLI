using CodeCLI.Common;

namespace CodeCLI.CommandServices.Blazor;
public class RazorService : CommandService
{
    private readonly string _templateName = "RazorTemp.txt";
    protected override string GetContent()
    {
        string content = ReadFile(_templateName);

        content = content.Replace(nameof(Name).ToVar(), Name);
        
        return content;
    }
}
