using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Install;
using CodeCLI.CommandServices.RegisterCodeCLI;

namespace CodeCLI.Commands.Config;
[Command("config carter(c)", "(config|c) (carter|c)$", Description = "Register Carter library to the project.")]
public class CarterConfigCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        try
        {
            ICommand installCommand = new InstallCarterCommand();
            installCommand.ExecuteAsync(console);
        }
        catch (Exception e)
        {
            console.Error.WriteLine("Falild to install Carter library.");
            console.Error.WriteLine($"Please try again.{e.Message}");
        }
        try
        {
            RegisterServices.RegisterCarter();

            console.WriteLine("Carter registerd successfully.");
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
