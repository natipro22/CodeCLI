using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.MediatR;
[Command("generate mediatr handler", "(generate|g) (mediatr|m) (handler|h)$", Description = "Creates a new, generic request handler definition using MediatR in the given project.")]
public class HandlerCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the request.")]
    public string Name { get; set; } = string.Empty;

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
