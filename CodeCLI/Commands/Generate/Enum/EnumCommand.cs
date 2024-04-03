using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.Enum;
[Command("generate enum(e)", @"(generate|g)?\s?(enum|e)$", Description = "Generates a new, generic enum definition in the given project.")]
public class EnumCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the enum.")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService enumService = CommandServiceFactory.GetEnumService(Name, Path);

        string fileName = enumService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
