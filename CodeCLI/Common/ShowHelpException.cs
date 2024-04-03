using CliFx.Exceptions;

namespace CodeCLI.Common;
public class ShowHelpException : CliFxException
{
    public ShowHelpException(string message) : base(message, 1, true)
    {

    }
    public ShowHelpException(string message, int exitCode = 1, bool showHelp = false, Exception? innerException = null) : base(message, exitCode, showHelp, innerException)
    {
    }
}
