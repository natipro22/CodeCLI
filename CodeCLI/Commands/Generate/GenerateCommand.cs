using CliFx.Attributes;
using CliFx.Infrastructure;

namespace CodeCLI.Commands.Generate;
[Command("generate(g)", @"^\b(generate|g)\b$", Description = "Generates and/or modifies files based on a schematic.")]
public class GenerateCommand : CommandBase
{

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
