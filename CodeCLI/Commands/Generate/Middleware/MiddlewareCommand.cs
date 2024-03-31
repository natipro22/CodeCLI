using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.CommandServices.RegisterCodeCLI;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.Middleware;
[Command("generate middleware(mw)", "(generate|g) (middleware|mw)$", Description = "Creates a new, generic ASP.NET Core middleware definition in the given project.")]
public class MiddlewareCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the middleware.")]
    public string Name { get; set; } = string.Empty;
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        ICommandService commandService = CommandServiceFactory.GetMiddlewareService(Name, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);

        RegisterServices.RegisterMiddleware(Name);

        return ValueTask.CompletedTask;
    }
}
