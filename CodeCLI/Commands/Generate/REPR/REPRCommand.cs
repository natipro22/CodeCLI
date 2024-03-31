using CliFx.Attributes;
using CliFx.Infrastructure;

namespace CodeCLI.Commands.Generate.REPR;
[Command("generate repr", "(generate|g) (repr)$", Description = "")]
public class REPRCommand : BaseCommand
{
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
