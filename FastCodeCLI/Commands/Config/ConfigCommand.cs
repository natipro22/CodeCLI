using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCLI.Commands.Config;
[Command("config", "(config|c)$", Description = "configure dependency to the ASP.NET CORE projects")]
public class ConfigCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        console.WriteLine("config workding.");
        return ValueTask.CompletedTask;
    }
}
