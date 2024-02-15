using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using CodeCLI.Common;

namespace Code.Commands.Request;
[Command("generate request", "(generate|g) (request|rq)$", Description = "Creates a new, generic request definition using MediatR in the given project.")]
public class RequestCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the request.")]
    public string? Name { get; set; }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}.cs";
        File.WriteAllText(name, Content.Class(Name!));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
