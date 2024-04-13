using CliFx.Attributes;
using CliFx.Infrastructure;

namespace CodeCLI.Commands.Generate.FluentValidation;
[Command("generate(g) fluent-validation(fv)", @"(generate|g)\b (fluent-validation|fv)$", Description = "FluentValidation is a .NET library for building strongly-typed validation rules.")]
public class FluentValidationCommand : CommandBase
{

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        return ShowCommandHelpAsync();
    }
}
