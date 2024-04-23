using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.CommandServices.MediatR;

namespace CodeCLI.Commands.Generate.REPR;
[Command("generate(g) repr query(q)", @"^\b(generate|g)\b \b(repr)\b \b(query|q)\b$", Description = "Creates a new, generic feature using MediatR, FluentValidation and Carter definition in the given project.")]
public class REPRQueryCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the REPR")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(Path))
        {
            Path = Name;
        }
        Name = System.IO.Path.GetFileName(Name);
        string response = $"{Name}ResponseDto";
        ICommandService request = CommandServiceFactory.GetRequestService(Name, response, CQRS.Query, Path);
        ICommandService handler = CommandServiceFactory.GetHandlerService(Name, response, CQRS.Query, Path);
        ICommandService validator = CommandServiceFactory.GetValidatorService($"{Name}{nameof(CQRS.Query)}", Path);
        ICommandService endpoint = CommandServiceFactory.GetEndpointService(Name, Path);
        ICommandService recordService = CommandServiceFactory.GetRecordService(response, string.Empty, Enumerable.Empty<string>(), Path);

        request.CreateFile();
        handler.CreateFile();
        validator.CreateFile();
        endpoint.CreateFile();
        recordService.CreateFile();

        console.Output.WriteLine($"{Name} feature created succesfully.");

        return ValueTask.CompletedTask;

    }
}
