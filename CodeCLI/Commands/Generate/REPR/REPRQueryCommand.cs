using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Generate;
using CodeCLI.CommandServices;
using CodeCLI.CommandServices.MediatR;
using CodeCLI.Common;
using System.Xml.Linq;

namespace CodeCLI.Commands.Generate.REPR;
[Command("generate repr query", "(generate|g) (repr) (query|q)$")]
public class REPRQueryCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the REPR")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        if (string.IsNullOrEmpty(Path))
        {
            Path = Name;
        }
        ICommandService request = CommandServiceFactory.GetRequestService(Name, "int", CQRS.Query, Path + Name);
        ICommandService handler = CommandServiceFactory.GetHandlerService(Name, "int", CQRS.Query, Path + Name);
        ICommandService validator = CommandServiceFactory.GetValidatorService($"{Name}{nameof(CQRS.Query)}", Path);


        request.CreateFile();
        handler.CreateFile();
        validator.CreateFile();
        console.Output.WriteLine($"{Name} feature created succesfully.");

        return ValueTask.CompletedTask;

    }
}
