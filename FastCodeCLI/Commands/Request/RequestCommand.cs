using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.Request;
[Command("generate request", "(generate|g) (mediatr|m) (request|r)$", Description = "Creates a new, generic request definition using MediatR in the given project.")]
public class RequestCommand : BaseCommand
{
    private string _name = string.Empty;

    [CommandParameter(0, IsRequired = true, Description = "The name of the request.")]
    public string Name { get => _name; set => _name = value.ToPascalCase(); }

    [CommandParameter(1, IsRequired = false, Description = "The name of the response.")]
    public string Response { get; set; } = "int";

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}.cs";
        File.WriteAllText(name, Content.Request(Name!, Response));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
