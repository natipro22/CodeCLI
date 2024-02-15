using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Interface;
[Command("g i", Description = "Creates a new, generic interface definition in the given project.")]
public class ICommand : InterfaceCommand
{
}
