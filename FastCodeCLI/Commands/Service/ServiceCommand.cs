using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.Common;

namespace Code.Commands.Service;
[Command("generate service", "(generate|g) (service|s)$", Description = "Creates a new, generic service definition in the given project.")]
public class ServiceCommand : BaseCommand
{
    private string _name = string.Empty;

    [CommandParameter(0, IsRequired = true, Description = "The name of the service.")]
    public string Name { get => _name; set => _name = value.ToPascalCase(); }

    [CommandParameter(1, IsRequired = false, Description = "The name of the service.")]
    public string Extends { get; set; } = string.Empty;

    [CommandParameter(2, IsRequired = false, Description = "The name of the service.")]
    public IEnumerable<string> Implements { get; set; } = Enumerable.Empty<string>();

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}Service.cs";
        File.WriteAllText(name, Content.Service(Name!, Extends, Implements));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
