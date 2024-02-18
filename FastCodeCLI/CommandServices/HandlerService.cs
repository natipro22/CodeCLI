
namespace Code.CommandServices;

public class HandlerService : ClassService, ICommandService
{
    private static IEnumerable<string> usings = new List<string> { "using MediatR;" };
    public HandlerService(string name, string response, string directory)
        : base(
            name: $"{name}Handler", 
            implements: new List<string> { $"IRequestHandler<{name}, {response}>" },
            usings: usings,
            body: $"\tpublic async Task<{response}> Handle({name} request, CancellationToken cancellationToken)\n" +
                    "\t{\n" +
                    $"\t\treturn new {response}();\n" +
                    "\t}\n"
            )
    {
        _directory = directory;
    }
}
