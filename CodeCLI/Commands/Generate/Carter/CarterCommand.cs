﻿using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.Carter;
[Command("generate endpoint(ep)", @"(generate|g)?\s?(endpoint|ep)$", Description = "Creates a new, generic endpoint definition using carter in the given project.")]
public class CarterCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the endpoint.")]
    public string Name { get; set; } = string.Empty;
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService endpoint = CommandServiceFactory.GetEndpointService(Name, Path);
        var fileName = endpoint.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
