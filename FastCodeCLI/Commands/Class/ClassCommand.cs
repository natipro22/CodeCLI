using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;

namespace Code.Commands.Class;
[Command("generate class", Description = "Creates a new, generic class definition in the given project.")]
public class ClassCommand : BaseCommand
{

    [CommandParameter(0, IsRequired = true, Description = "The name of the class.")]
    public string Name { get; set; }

    [CommandOption('p', Description = "The name of the project.")]
    public string Project { get; set; }

    [CommandOption('a', Description = "abstract class")]
    public bool Abstract { get; set; } = false;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}.cs";
        File.WriteAllText(name, Content.Class(Name));
        console.Output.WriteLine($"{name} created succesfully.");
        return ValueTask.CompletedTask;
    }
}
