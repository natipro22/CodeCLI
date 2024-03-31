using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.CommandServices;
using CodeCLI.Common;
using System.Xml.Linq;

namespace CodeCLI.Commands.Generate.MediatR.Notification;
[Command("generate mediatr notification(n)", "(generate|g) (mediatr|m) (notification|n)$", Description = "Creates a new, generic event notification definition using MediatR in the given project.")]
public class NotificationCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the notification.")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellation)
    {
        ICommandService commandService = CommandServiceFactory.GetNotificationService(Name, Path);

        string fileName = commandService.CreateFile();

        console.FileCreated(fileName);
        return ValueTask.CompletedTask;
    }
}
