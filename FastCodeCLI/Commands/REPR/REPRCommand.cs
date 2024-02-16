using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.REPR;
[Command("generate repr", "(generate|g) (repr)")]
public class REPRCommand : BaseCommand
{
    private string _name = string.Empty;

    [CommandParameter(0, IsRequired = true, Description = "The name of the REPR")]
    public string Name { get => _name; set => _name = value.ToPascalCase(); }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}.cs";
        File.WriteAllText(name, Content.REPR(Name!));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
