using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Class;
using Code.Commands.Generate;
using Code.CommandServices;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.REPR;
[Command("generate repr", "(generate|g) (repr)$")]
public class REPRCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the REPR")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        Directory.CreateDirectory(Name);
        ICommandService request = CommandServiceFactory.GetRequestService(Name, "int", Path + Name);

        ICommandService handler = CommandServiceFactory.GetHandlerService($"{Name}Request", "int", Path + Name);


        request.CreateFile();
        handler.CreateFile();
        console.Output.WriteLine("files created succesfully.");
        // ICommandService minimalApi = CommandServiceFactory.GetMinimalApiService(Name);

        return ValueTask.CompletedTask;

    }
}
