using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.FluentValidation;
[Command("generate fluent-validation(fv)", "(generate|g) (fluent-validation|fv)$", Description = "FluentValidation is a .NET library for building strongly-typed validation rules.")]
public class FluentValidationCommand : CommandBase
{

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
