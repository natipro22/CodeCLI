using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;
using System.Xml.Linq;

namespace CodeCLI.Commands.Generate.Blazor;
[Command("generate blazor css", "(generate|g) (blazor|b) (css)$", Description = "It is a style sheet language used for describing the presentation of a document written in a markup language like HTML.")]
public class CssCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the css.")]
    public string Name { get; set; } = string.Empty;
    public override ValueTask ExecuteAsync(IConsole console)
    {
        ICommandService commandService = CommandServiceFactory.GetRazorService(Name, Path!);
        try
        {
            string fileName = commandService.CreateFile();
            // write success message on the console
            console.FileCreated(fileName);
        }
        catch (Exception e)
        {
            console.Error.WriteLine(e.Message);
        }
        return ValueTask.CompletedTask;
    }
}
