using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Controller;
[Command("g ct", Description = "Creates a new, generic controller definition in the given project.")]
public class CtCommand : ControllerCommand
{

}
