﻿using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.Controller;
[Command("generate(g) controller(ct)", @"^\b(generate|g)\b \b(controller|ct)\b$", Description = "Creates a new, generic controller definition in the given project.")]
public class ControllerCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the controller")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService commandService = CommandServiceFactory.GetControllerService(Name, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
