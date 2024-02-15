using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using CodeCLI.Common;

namespace Code.Commands.Interface;
[Command("generate interface", "(generate|g) (interface|i)$", Description = "Creates a new, generic interface definition in the given project.")]
public class InterfaceCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the interface.")]
    public string? Name { get; set; }


    [CommandOption('x', Description = "A prefix to apply to generated selectors.")]
    public char Prefix { get; set; } = 'I';


    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Prefix}{Name}.cs";
        File.WriteAllText(name, Content.Interface(Name!, Prefix));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
