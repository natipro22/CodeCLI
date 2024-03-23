using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Common;

namespace FastCodeCLI.Commands.FluentValidation;
[Command("generate fluent-validation", "(generate|g) (fluent-validation|fv)$", Description = "FluentValidation is a .NET library for building strongly-typed validation rules.")]
public class FluentValidationCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        throw new ShowHelpException("Fluent Validation Command Help");
    }
}
