﻿using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.REPR;
[Command("g repr")]
public class GREPRCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the REPR")]
    public string Name { get; set; }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        throw new NotImplementedException();
    }
}
