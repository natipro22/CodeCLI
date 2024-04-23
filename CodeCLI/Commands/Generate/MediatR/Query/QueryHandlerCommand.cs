using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.CommandServices.MediatR;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.MediatR;
[Command("generate(g) mediatr(m) query-handler(qh)", @"^\b(generate|g)\b \b(mediatr|m)\b \b(query-handler|qh)\b$", Description = "Creates a new, generic request query handler definition using MediatR in the given project.")]
public class QueryHandlerCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the request.")]
    public string Name { get; set; } = string.Empty;

    [CommandParameter(1, IsRequired = false, Description = "The name of the response.")]
    public string Response { get; set; } = "int";

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService commandService = CommandServiceFactory.GetHandlerService(Name, Response, CQRS.Query, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
