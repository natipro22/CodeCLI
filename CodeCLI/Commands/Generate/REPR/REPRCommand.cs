using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Generate;
using CodeCLI.CommandServices;
using CodeCLI.CommandServices.MediatR;
using CodeCLI.Common;
using System.Xml.Linq;

namespace CodeCLI.Commands.Generate.REPR;
[Command("generate repr", "(generate|g) (repr)$", Description = "")]
public class REPRCommand : BaseCommand
{

    public override ValueTask ExecuteAsync(IConsole console)
    {
        throw new ShowHelpException("REPR Help");
    }
}
