using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.CommandServices;
using Code.Common;

namespace Code.Commands.FluentValidation;
[Command("generate fluent-validation validator", "(generate|g) (fluent-validation|fv) (validator|v)$", Description = "Creates a new, generic request validator using MediatR in the given project.")]
public class ValidatorCommand : BaseCommand
{
    

    [CommandParameter(0, IsRequired = true, Description = "The name of the validator.")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        ICommandService commandService = CommandServiceFactory.GetValidatorService(Name);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
