using CliFx;
using CliFx.Attributes;
using CliFx.Exceptions;
using CliFx.Infrastructure;

namespace CodeCLI.Commands.Install;
[Command("install", "(install|i)$")]
public class InstallCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        throw new CliFxException("Help", 1, true);
    }
}
