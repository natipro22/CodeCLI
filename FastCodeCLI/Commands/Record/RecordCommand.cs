using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Record;
[Command("generate record", "(generate|g) (record|r)$", Description = "Creates a new, generic record definition in the given project.")]
public class RecordCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the record.")]
    public string Name { get; set; }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        throw new NotImplementedException();
    }
}
