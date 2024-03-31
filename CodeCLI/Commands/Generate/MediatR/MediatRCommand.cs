using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.MediatR;
[Command("generate mediatr(m)", "(generate|g) (mediatr|m)$", Description = "MediatR Library. Simple mediator implementation in .NET.")]
public class MediatRCommand : CommandBase
{
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
