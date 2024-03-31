using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Install;
using CodeCLI.CommandServices.RegisterCodeCLI;

namespace CodeCLI.Commands.Config;
[Command("config mediatr", "(config|c) (mediatr|m)$", Description = "Register MediatR library to the project.")]
public class MediatRConfigCommand : CommandBase
{
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
            RegisterServices.RegisterMediatR();

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
