using CliFx;
using CliFx.Attributes;
using CliFx.Exceptions;
using CliFx.Infrastructure;

namespace CodeCLI.Commands;
[Command]
public abstract class CommandBase : ICommand
{

    //[CommandOption("path", 'p', Description = "The path of the file.")]
    //public string Path { get; set; } = string.Empty;
    public async ValueTask ExecuteAsync(IConsole console)
    {

        var cancellationToken = console.RegisterCancellationHandler();
        try
        {
            await ValidateAsync(cancellationToken);
        }
        catch (NotImplementedException) { }
        try
        {
            await ExecuteCommandAsync(console, cancellationToken);
        }
        catch (TaskCanceledException ex)
        {
            await console.Error.WriteLineAsync(ex.Message);
        }
        catch (Exception e) when (e is not CommandException)
        {
            await console.Error.WriteLineAsync(e.Message);
        }

    }

    /// <summary>
    /// Shows help for the command
    /// </summary>
    public ValueTask ShowCommandHelpAsync()
    {
        throw new CommandException("Please define a follow up command", showHelp: true);
    }
    /// <summary>
    /// Asynchoronously executes the command
    /// </summary>
    public abstract ValueTask ExecuteCommandAsync(IConsole console, CancellationToken cancellationToken);

    /// <summary>
    /// Used to validate the command
    /// </summary>
    public virtual ValueTask ValidateAsync(CancellationToken cancellationToken)
    {
        return default;
    }
}

