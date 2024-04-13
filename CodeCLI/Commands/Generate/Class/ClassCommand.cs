using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.Class;
[Command("generate(g) class(c)", @"^(generate|g)\b (class|c)$", Description = "Creates a new, generic class definition in the given project.")]
public class ClassCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the class.")]
    public string Name { get; set; } = string.Empty;

    [CommandParameter(1, IsRequired = false, Description = "The name of the base class.")]
    public string Extends { get; set; } = string.Empty;

    [CommandParameter(2, IsRequired = false, Description = "The names of the interfaces.")]
    public IEnumerable<string> Implements { get; set; } = Enumerable.Empty<string>();

    [CommandOption("abstract", 'a', Description = "abstract class")]
    public bool Abstract { get; set; } = false;

    [CommandOption("seald", 's', Description = "seald class")]
    public bool Seald { get; set; } = false;

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        // Get the class service
        ICommandService classService = CommandServiceFactory.GetClassService(Name, Extends, Implements, Abstract, Seald, Path);
        string fileName = classService.CreateFile();
        // write success message on the console
        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
