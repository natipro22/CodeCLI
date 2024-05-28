using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Install;
using CodeCLI.CommandServices.RegisterCodeCLI;

namespace CodeCLI.Commands.Config;
[Command("config mediatr", @"^\b(config|c)\b \b(mediatr|m)\b$", Description = "Register MediatR library to the project.")]
public class MediatRConfigCommand : CommandBase
{
    [CommandParameter(0, IsRequired = false, Description = "The name of the startup class.")]
    public string FileName { get; set; } = "Program.cs";
    public override ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken)
    {
        try
        {
            ICommand installCommand = new InstallMediatRCommand();
            installCommand.ExecuteAsync(console);
        }
        catch (Exception e)
        {
            console.Error.WriteLine("Falild to install MediatR library.");
            console.Error.WriteLine($"Please try again.{e.Message}");
        }
        try
        {
            RegisterServices.RegisterMediatR(FileName);

            console.WriteLine("MediatR registerd successfully.");
        }
        catch (FileNotFoundException)
        {
            console.Error.WriteLine("Error: file not found.");
        }
        catch (Exception ex)
        {
            console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
        return ValueTask.CompletedTask;
    }
}
