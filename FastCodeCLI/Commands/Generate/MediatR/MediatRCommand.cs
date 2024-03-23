using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.MediatR;
[Command("generate mediatr", "(generate|g) (mediatr|m)$", Description = "MediatR Library. Simple mediator implementation in .NET.")]
public class MediatRCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        throw new ShowHelpException("MediatR Command Help");
    }
}
