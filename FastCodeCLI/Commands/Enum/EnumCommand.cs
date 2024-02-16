using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.Common;

namespace Code.Commands.Enum;
[Command("generate enum", "(generate|g) (enum|e)$", Description = "Generates a new, generic enum definition in the given project.")]
public class EnumCommand : BaseCommand
{
    private string _name = string.Empty;

    [CommandParameter(0, IsRequired = true, Description = "The name of the interface.")]
    public string Name { get => _name; set => _name = value.ToPascalCase(); }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}.cs";
        File.WriteAllText(name, Content.Enum(Name!));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
