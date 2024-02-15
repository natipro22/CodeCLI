﻿using CliFx.Attributes;
using CliFx.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Service;
[Command("generate service", "(generate|g) (service|s)$", Description = "Creates a new, generic service definition in the given project.")]
public class ServiceCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the service.")]
    public string Name { get; set; }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        throw new NotImplementedException();
    }
}
