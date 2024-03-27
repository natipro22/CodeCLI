using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCLI.Commands.Generate.Blazor;
[Command("generate blazor component(c)", "(generate|g) (blazor|b) (component|c)$", Description = "Creates a new, generic component definition in the given project.")]
public class ComponentCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the component.")]
    public string Name { get; set; } = string.Empty;
    public override ValueTask ExecuteAsync(IConsole console)
    {
		if (string.IsNullOrEmpty(Path))
		{
			Path = Name;
		}
		try
		{

			ICommandService component = CommandServiceFactory.GetComponentService(Name, Path);
            ICommandService razor = CommandServiceFactory.GetRazorService(Name, Path);
            ICommandService css = CommandServiceFactory.GetCssService(Name, Path);

			var file = component.CreateFile();
            razor.CreateFile();
            css.CreateFile();
			console.WriteLine($"{Name} component created succesfully");

		}
		catch (Exception)
		{
			throw;
		}
		return ValueTask.CompletedTask;
    }
}
