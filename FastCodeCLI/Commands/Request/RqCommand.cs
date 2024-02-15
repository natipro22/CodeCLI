using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Request;
[Command("g rq", Description = "Creates a new, generic request definition using MediatR in the given project.")]
public class RqCommand : RequestCommand
{

}
