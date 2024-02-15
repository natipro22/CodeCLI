using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Record;
[Command("generate record", Description = "Creates a new, generic record definition in the given project.")]
public class RCommand : RecordCommand
{
}
