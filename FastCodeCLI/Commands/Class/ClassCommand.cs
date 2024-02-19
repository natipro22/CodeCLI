using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.CommandServices;
using Code.Common;
using System.Text.Json;

namespace Code.Commands.Class;
[Command("generate class", "(generate|g) (class|c)$", Description = "Creates a new, generic class definition in the given project.")]
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

    public override ValueTask ExecuteAsync(IConsole console)
    {
        // Get the class service
        ICommandService classService = CommandServiceFactory.GetClassService(Name, Extends, Implements, Abstract);
        try
        {
            string fileName = classService.CreateFile();
            // write success message on the console
            console.FileCreated(fileName);
        }
        catch (System.Exception e)
        {
            console.Error.WriteLine(e.Message);
        }
        return ValueTask.CompletedTask;
    }
}
