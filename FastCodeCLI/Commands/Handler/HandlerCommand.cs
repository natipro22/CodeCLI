using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Handler;
[Command("generate handler", "(generate|g) (handler|h)$", Description = "Creates a new, generic request handler definition using MediatR in the given project.")]
public class HandlerCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the request.")]
    public string Name { get; set; }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        throw new NotImplementedException();
    }
}
