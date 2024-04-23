using CliFx.Attributes;
using CliFx.Infrastructure;

namespace CodeCLI.Commands.Install;
[Command("install", @"^\b(install|i)\b$")]
public class InstallCommand : CommandBase
{
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
