using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.CommandServices.MediatR;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.MediatR;
[Command("generate mediatr command-handler(ch)", @"(generate|g)?\s?(mediatr|m) (command-handler|ch)$", Description = "Creates a new, generic request command handler definition using MediatR in the given project.")]
public class CommandHandlerCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the command handler.")]
    public string Name { get; set; } = string.Empty;

    [CommandParameter(1, IsRequired = false, Description = "The name of the response.")]
    public string Response { get; set; } = "int";

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService commandService = CommandServiceFactory.GetHandlerService(Name, Response, CQRS.Command, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
