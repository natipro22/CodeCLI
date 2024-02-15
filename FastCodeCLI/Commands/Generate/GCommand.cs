using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Generate;
[Command("g", Description = "alias of generate command")]
public class GCommand : GenerateCommand
{

}

