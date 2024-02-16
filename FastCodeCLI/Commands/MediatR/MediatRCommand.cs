using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace FastCodeCLI.Commands.MediatR;
[Command("generate mediatr", "(generate|g) (mediatr|m)$", Description = "MediatR Library. Simple mediator implementation in .NET.")]
public class MediatRCommand : ICommand
{
    [CommandParameter(0, IsRequired = true)]
    public string? Command { get; set; }
    public ValueTask ExecuteAsync(IConsole console)
    {
        return default;
    }
}
