using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Service;
[Command("g s", Description = "Creates a new, generic service definition in the given project.")]
public class SCommand : ServiceCommand
{

}
