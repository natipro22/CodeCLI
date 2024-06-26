﻿using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.Service;
[Command("generate(g) service(s)", @"^\b(generate|g)\b \b(service|s)\b$", Description = "Creates a new, generic service definition in the given project.")]
public class ServiceCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the service.")]
    public string Name { get; set; } = string.Empty;

    [CommandParameter(1, IsRequired = false, Description = "The name of the service.")]
    public string Extends { get; set; } = string.Empty;

    [CommandParameter(2, IsRequired = false, Description = "The name of the service.")]
    public IEnumerable<string> Implements { get; set; } = Enumerable.Empty<string>();

    [CommandOption("abstract", 'a', Description = "abstract class")]
    public bool Abstract { get; set; } = false;

    [CommandOption("sealed", 's', Description = "seald class")]
    public bool Sealed { get; set; } = false;

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        ICommandService commandService = CommandServiceFactory.GetClassService($"{Name}Service", Extends, Implements, Abstract, Sealed, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
