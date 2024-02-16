using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.Common;

namespace Code.Commands.Class;
[Command("generate class", "(generate|g) (class|c)$", Description = "Creates a new, generic class definition in the given project.")]
public class ClassCommand : BaseCommand
{

    [CommandParameter(0, IsRequired = true, Description = "The name of the class.")]
    public string Name { get; set; } = string.Empty;

    [CommandOption("abstract", 'a', Description = "abstract class")]
    public bool Abstract { get; set; } = false;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string fileName = $"{Name}.cs";
        File.WriteAllText(fileName, Content.Class(Name, Abstract));
        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
