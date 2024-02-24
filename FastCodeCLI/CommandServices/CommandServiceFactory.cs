using System.Text.Json;
using System.Xml.Linq;

namespace Code.CommandServices;

public static class CommandServiceFactory
{
    public static ICommandService GetClassService(string name, string extends, IEnumerable<string> implements, bool isAbstract, string path)
        => new ClassService(name, extends, implements, isAbstract, path);

    public static ICommandService GetInterfaceService(string name, char prefix, string path)
        => new InterfaceService(name, prefix, path);

    public static ICommandService GetEnumService(string name, string path)
        => new EnumService(name, path);

    public static ICommandService GetRecordService(string name, string path)
        => new RecordService(name, path);

    public static ICommandService GetControllerService(string name, string path)
        => new ControllerService(name, path);

    public static ICommandService GetMinimalApiService(string name, string path)
        => new MinimalApiService(name, path);
    public static ICommandService GetValidatorService(string name, string path)
        => new ValidatorService(name, path);

    public static ICommandService GetRequestService(string name, string response, string directory = "")
        => new RequestService(name, response, directory);
    
    public static ICommandService GetHandlerService(string name, string response, string directory = "")
        => new HandlerService(name, response, directory);
    
}
