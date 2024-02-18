

namespace Code.CommandServices;

public class RequestService : RecordService, ICommandService
{
    private static IEnumerable<string> usings = new List<string> { "using MediatR;" };

    public RequestService(string name, string response)
        : base($"{name}Request", new List<string> { $"IRequest<{response}>" }, usings)
    {
    }

    public RequestService(string name, string response, string directory)
        : base($"{name}Request", new List<string> { $"IRequest<{response}>" }, usings)
    {
        _directory = directory;
    }
}
