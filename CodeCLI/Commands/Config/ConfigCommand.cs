using CliFx.Attributes;
using CliFx.Infrastructure;

namespace CodeCLI.Commands.Config;
[Command("config", "(config|c)$", Description = "configure dependency to the ASP.NET CORE projects")]
public class ConfigCommand : CommandBase
{
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
