using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;

namespace CodeCLI.Commands.Generate.Blazor;
[Command("generate blazor component(c)", @"(generate|g)?\s?(blazor|b) (component|c)$", Description = "Creates a new, generic component definition in the given project.")]
public class ComponentCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the component.")]
    public string Name { get; set; } = string.Empty;
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        Path = string.IsNullOrEmpty(Path) ? Name : Path;
        ICommandService component = CommandServiceFactory.GetComponentService(Name, Path);
        ICommandService razor = CommandServiceFactory.GetRazorService(Name, Path);
        ICommandService css = CommandServiceFactory.GetCssService(Name, Path);

        component.CreateFile();
        razor.CreateFile();
        css.CreateFile();

        console.Output.WriteLine($"{Name} component created succesfully");
        return ValueTask.CompletedTask;
    }
}
