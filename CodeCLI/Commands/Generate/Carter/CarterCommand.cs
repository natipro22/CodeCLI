﻿using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCLI.Commands.Generate.Carter;
[Command("generate endpoint(ep)", "(generate|g) (endpoint|ep)$", Description = "Creates a new, generic endpoint definition using carter in the given project.")]
public class CarterCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the endpoint.")]
    public string Name { get; set; } = string.Empty;
    public override ValueTask ExecuteAsync(IConsole console)
    {
        ICommandService endpoint = CommandServiceFactory.GetEndpointService(Name, Path);
        var fileName = endpoint.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}