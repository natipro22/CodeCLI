using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace Code.Commands.Generate;
[Command("generate", "(generate|g)$", Description = "Generates and/or modifies files based on a schematic.")]
public class GenerateCommand : ICommand
{
    [CommandParameter(0, IsRequired = true)]
    public string? Command { get; set; }

    public ValueTask ExecuteAsync(IConsole console)
    {
        console.Output.WriteLine("generate working");
        return ValueTask.CompletedTask;
    }
}
