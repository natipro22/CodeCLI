using CliFx.Attributes;
using CliFx.Infrastructure;

namespace CodeCLI.Commands.Generate.Blazor;
[Command("generate blazor(b)", @"(generate|g)?(?:\s|$)(blazor|b)$", Description = "Blazor is a modern front-end web framework based on HTML, CSS, and C# that helps you build web apps faster.")]
public class BlazorCommand : BaseCommand
{
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        return ShowCommandHelpAsync();
    }
}
