using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Common;

namespace CodeCLI.Commands.Config;
[Command("config", "(config|c)$", Description = "configure dependency to the ASP.NET CORE projects")]
public class ConfigCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        throw new ShowHelpException("Config Help");
    }
}
