using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.Handler;
[Command("generate handler", "(generate|g) (mediatr|m) (handler|h)$", Description = "Creates a new, generic request handler definition using MediatR in the given project.")]
public class HandlerCommand : BaseCommand
{
    private string _name = string.Empty;

    [CommandParameter(0, IsRequired = true, Description = "The name of the request.")]
    public string Name { get => _name; set => _name = value.ToPascalCase(); }

    [CommandParameter(1, IsRequired = false, Description = "The name of the response.")]
    public string Response { get; set; } = "int";

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}Handler.cs";
        File.WriteAllText(name, Content.Handler(Name!, Response));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
