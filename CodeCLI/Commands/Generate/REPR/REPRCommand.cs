using CliFx.Attributes;
using CliFx.Infrastructure;

namespace CodeCLI.Commands.Generate.REPR;
[Command("generate(g) repr", @"(generate|g)\b (repr)\b$", Description = "Request-EndPoint-Response")]
public class REPRCommand : BaseCommand
{
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
