using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.Controller;
[Command("generate controller", "(generate|g) (controller|ct)$", Description = "Creates a new, generic controller definition in the given project.")]
public class ControllerCommand : BaseCommand
{
    private string _name = string.Empty;

    [CommandParameter(0, IsRequired = true, Description = "The name of the controller")]
    public string Name { get => _name; set => _name = value.ToPascalCase(); }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}Controller.cs";
        File.WriteAllText(name, Content.Controller(Name!));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
