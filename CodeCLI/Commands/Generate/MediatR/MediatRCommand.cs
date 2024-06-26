using CliFx.Attributes;
using CliFx.Infrastructure;

namespace CodeCLI.Commands.Generate.MediatR;
[Command("generate(g) mediatr(m)", @"^\b(generate|g)\b \b(mediatr|m)\b$", Description = "MediatR Library. Simple mediator implementation in .NET.")]
public class MediatRCommand : CommandBase
{
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
