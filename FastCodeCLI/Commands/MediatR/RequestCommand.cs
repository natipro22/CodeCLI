using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.CommandServices;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.MediatR;
[Command("generate mediatr request", "(generate|g) (mediatr|m) (request|r)$", Description = "Creates a new, generic request definition using MediatR in the given project.")]
public class RequestCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the request.")]
    public string Name { get; set; } = string.Empty;

    [CommandParameter(1, IsRequired = false, Description = "The name of the response.")]
    public string Response { get; set; } = "int";

    public override ValueTask ExecuteAsync(IConsole console)
    {
        ICommandService commandService = CommandServiceFactory.GetRequestService(Name, Response, Path);

        string fileName = commandService.CreateFile();
        
        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
