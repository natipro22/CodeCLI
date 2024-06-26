using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.FluentValidation;
[Command("generate(g) fluent-validation(fv) validator(v)", @"^\b(generate|g)\b \b(fluent-validation|fv)\b? \b(validator|v)\b$", Description = "Creates a new, generic request validator using MediatR in the given project.")]
public class ValidatorCommand : BaseCommand
{


    [CommandParameter(0, IsRequired = true, Description = "The name of the validator.")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService commandService = CommandServiceFactory.GetValidatorService(Name, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
