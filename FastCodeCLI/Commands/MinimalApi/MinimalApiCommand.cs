using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.MinimalApi;
[Command("generate minimal-api", "(generate|g) (minimal-api|ma)$", Description = "Creates a new, generic minimal api definition in the given project.")]
public class MinimalApiCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the minimal api")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}Api.cs";
        File.WriteAllText(name, Content.MinimalApi(Name!));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
