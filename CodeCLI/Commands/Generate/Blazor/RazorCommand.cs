using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCLI.Commands.Generate.Blazor;

[Command("generate blazor razor", "(generate|g) (blazor|b) (razor|r)$", Description = "Creates a new, generic razor page definition in the given project.")]
public class RazorCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the razor.")]
    public string Name { get; set; } = string.Empty;
    public override ValueTask ExecuteAsync(IConsole console)
    {
        ICommandService commandService = CommandServiceFactory.GetRazorService(Name, Path);
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
