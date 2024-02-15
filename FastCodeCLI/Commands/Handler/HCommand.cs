using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Handler;
[Command("generate handler", Description = "Creates a new, generic request handler definition using MediatR in the given project.")]
public class HCommand : HandlerCommand
{

}
