using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace FastCodeCLI.Commands.FluentValidation;
[Command("generate fluent-validation", "(generate|g) (fluent-validation|fv)$", Description = "FluentValidation is a .NET library for building strongly-typed validation rules.")]
public class FluentValidationCommand : ICommand
{
    [CommandParameter(0, IsRequired = true)]
    public string? Command { get; set; }
    public ValueTask ExecuteAsync(IConsole console)
    {
        return default;
    }
}
