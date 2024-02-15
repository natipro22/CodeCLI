using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using CodeCLI.Common;

namespace Code.Commands.REPR;
[Command("generate repr", "(generate|g) (repr)")]
public class REPRCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the REPR")]
    public string? Name { get; set; }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}.cs";
        File.WriteAllText(name, Content.Class(Name!));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
