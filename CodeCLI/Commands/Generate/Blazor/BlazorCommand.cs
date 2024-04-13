using CliFx.Attributes;
using CliFx.Infrastructure;

namespace CodeCLI.Commands.Generate.Blazor;
[Command("generate(g) blazor(b)", @"\b(generate|g)\b (blazor|b)$", Description = "Blazor is a modern front-end web framework based on HTML, CSS, and C# that helps you build web apps faster.")]
public class BlazorCommand : BaseCommand
{
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        return ShowCommandHelpAsync();
    }
}
