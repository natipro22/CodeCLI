using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using CodeCLI.Common;

namespace Code.Commands.Record;
[Command("generate record", "(generate|g) (record|r)$", Description = "Creates a new, generic record definition in the given project.")]
public class RecordCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the record.")]
    public string? Name { get; set; }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}.cs";
        File.WriteAllText(name, Content.Class(Name!));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
