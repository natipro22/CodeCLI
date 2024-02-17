using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.CommandServices;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.Record;
[Command("generate record", "(generate|g) (record|r)$", Description = "Creates a new, generic record definition in the given project.")]
public class RecordCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the record.")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        ICommandService commandService = CommandServiceFactory.GetRecordService(Name);
        
        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
