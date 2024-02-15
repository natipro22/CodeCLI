using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Enum;
[Command("g e", Description = "Generates a new, generic enum definition in the given project.")]
public class ECommand : EnumCommand
{

}
