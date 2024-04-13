using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.CommandServices.MediatR;

namespace CodeCLI.Commands.Generate.REPR;
[Command("generate(g) repr command(c)", @"(generate|g)\b (repr)\b (command|c)\b$")]
public class REPRCommandCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the REPR")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(Path))
        {
            Path = Name;
        }
        string response = $"{Name}ResponseDto";
        ICommandService request = CommandServiceFactory.GetRequestService(Name, response, CQRS.Command, Path);
        ICommandService handler = CommandServiceFactory.GetHandlerService(Name, response, CQRS.Command, Path);
        ICommandService validator = CommandServiceFactory.GetValidatorService($"{Name}{nameof(CQRS.Command)}", Path);
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
