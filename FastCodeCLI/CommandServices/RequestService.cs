

namespace Code.CommandServices;

public class RequestService : RecordService, ICommandService
{
    private static IEnumerable<string> usings = new List<string> { "using MediatR;" };

    public RequestService(string name, string response)
        : base(name, new List<string> { $"IRequest<{response}>" }, usings)
    {
    }
}
