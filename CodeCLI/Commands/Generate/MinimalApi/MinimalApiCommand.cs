using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.MinimalApi;
[Command("generate minimal-api(ma)", "(generate|g) (minimal-api|ma)$", Description = "Creates a new, generic minimal api definition in the given project.")]
public class MinimalApiCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the minimal api")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        ICommandService commandService = CommandServiceFactory.GetMinimalApiService(Name, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
