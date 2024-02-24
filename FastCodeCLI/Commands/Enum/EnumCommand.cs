using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.CommandServices;
using Code.Common;

namespace Code.Commands.Enum;
[Command("generate enum", "(generate|g) (enum|e)$", Description = "Generates a new, generic enum definition in the given project.")]
public class EnumCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the interface.")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        ICommandService enumService = CommandServiceFactory.GetEnumService(Name, Path);

        string fileName = enumService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
