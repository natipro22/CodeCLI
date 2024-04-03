﻿using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;

namespace CodeCLI.Commands.Generate.MediatR.Notification;
[Command("generate mediatr notification-handler(nh)", @"(generate|g)?\s?(mediatr|m) (notification-handler|nh)$", Description = "Creates a new, generic event notification handler definition using MediatR in the given project.")]

public class NotificationHandlerCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the notification handler.")]
    public string Name { get; set; } = string.Empty;
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService commandService = CommandServiceFactory.GetNotificationHandlerService(Name, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
