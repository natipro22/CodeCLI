using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.Blazor;

[Command("generate blazor razor(r)", "(generate|g) (blazor|b) (razor|r)$", Description = "Creates a new, generic razor page definition in the given project.")]
public class RazorCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the razor.")]
    public string Name { get; set; } = string.Empty;
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService commandService = CommandServiceFactory.GetRazorService(Name, Path);
        
        string fileName = commandService.CreateFile();
        // write success message on the console
        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
