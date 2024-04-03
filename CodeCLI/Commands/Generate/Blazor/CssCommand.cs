using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.Blazor;
[Command("generate blazor css", @"(generate|g)?\s?(blazor|b) (css)$", Description = "It is a style sheet language used for describing the presentation of a document written in a markup language like HTML.")]
public class CssCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the css.")]
    public string Name { get; set; } = string.Empty;
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService commandService = CommandServiceFactory.GetCssService(Name, Path!);

        string fileName = commandService.CreateFile();
        // write success message on the console
        console.FileCreated(fileName);

        return ValueTask.CompletedTask;
    }
}
