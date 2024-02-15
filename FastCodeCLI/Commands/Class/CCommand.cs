using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Class;
[Command("g c", Description = "Creates a new, generic class definition in the given project.")]
public class CCommand : ClassCommand
{
}
