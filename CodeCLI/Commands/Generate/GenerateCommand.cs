using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate;
[Command("generate", "(generate|g)$", Description = "Generates and/or modifies files based on a schematic.")]
public class GenerateCommand : CommandBase
{

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
