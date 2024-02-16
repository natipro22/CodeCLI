using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands;
using Code.Commands.Generate;
using Code.Common;

namespace Code.Commands.FluentValidation;
[Command("generate fluent-validation validator", "(generate|g) (fluent-validation|fv)^ (validator|v)$", Description = "Creates a new, generic request validator using MediatR in the given project.")]
public class ValidatorCommand : BaseCommand
{
    

    [CommandParameter(0, IsRequired = true, Description = "The name of the validator.")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string fileName = $"{Name}.cs";
        File.WriteAllText(fileName, Content.Validator(Name!));
        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
