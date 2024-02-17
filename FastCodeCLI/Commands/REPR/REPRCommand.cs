using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Class;
using Code.Commands.Generate;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.REPR;
[Command("generate repr", "(generate|g) (repr)")]
public class REPRCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the REPR")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}.cs";
        File.WriteAllText(name, Content.REPR(Name!));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
