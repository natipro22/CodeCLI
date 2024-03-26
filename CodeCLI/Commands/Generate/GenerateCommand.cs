using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate;
[Command("generate", "(generate|g)$", Description = "Generates and/or modifies files based on a schematic.")]
public class GenerateCommand : ICommand
{

    public ValueTask ExecuteAsync(IConsole console)
    {
        throw new ShowHelpException("Generate Help");
    }
}
