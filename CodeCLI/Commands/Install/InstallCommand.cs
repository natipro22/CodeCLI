using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Common;

namespace CodeCLI.Commands.Install;
[Command("install", "^(install|i)$")]
public class InstallCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        throw new ShowHelpException("Install Help");
    }
}
