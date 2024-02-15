using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.MinimalApi;
[Command("g ma", Description = "Creates a new, generic minimal api definition in the given project.")]
public class MACommand : MinimalApiCommand
{

}
