using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.CommandServices.MediatR;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.MediatR;
[Command("generate(g) mediatr(m) command(c)", @"(generate|g)\b (mediatr|m)\b (command|c)\b$", Description = "Creates a new, generic CQRS command definition using MediatR in the given project.")]
public class RequestCommandCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the command.")]
    public string Name { get; set; } = string.Empty;

    [CommandParameter(1, IsRequired = false, Description = "The name of the response.")]
    public string Response { get; set; } = "int";

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService commandService = CommandServiceFactory.GetRequestService(Name, Response, CQRS.Command, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
