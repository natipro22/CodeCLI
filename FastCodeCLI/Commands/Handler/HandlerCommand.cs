using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using CodeCLI.Common;

namespace Code.Commands.Handler;
[Command("generate handler", "(generate|g) (handler|h)$", Description = "Creates a new, generic request handler definition using MediatR in the given project.")]
public class HandlerCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the request.")]
    public string? Name { get; set; }
    [CommandParameter(1, IsRequired = false, Description = "The name of the response.")]
    public string? Response { get; set; } = "int";

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}Handler.cs";
        File.WriteAllText(name, Content.Handler(Name!, Response ??= "int"));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
