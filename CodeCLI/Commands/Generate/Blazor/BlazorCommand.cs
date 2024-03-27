using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCLI.Commands.Generate.Blazor;
[Command("generate blazor(b)", "(generate|g) (blazor|b)$", Description = "Blazor is a modern front-end web framework based on HTML, CSS, and C# that helps you build web apps faster.")]
public class BlazorCommand : BaseCommand
{
    public override ValueTask ExecuteAsync(IConsole console)
    {
        throw new ShowHelpException("Blazor Help");
    }
}
