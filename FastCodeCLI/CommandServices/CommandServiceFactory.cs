using System.Text.Json;
using System.Xml.Linq;

namespace Code.CommandServices;

public static class CommandServiceFactory
{
    public static ICommandService GetClassService(string name, string extends, IEnumerable<string> implements, bool isAbstract)
        => new ClassService(name, extends, implements, isAbstract);

    public static ICommandService GetInterfaceService(string name, char prefix)
        => new InterfaceService(name, prefix);

    public static ICommandService GetEnumService(string name)
        => new EnumService(name);

    public static ICommandService GetRecordService(string name)
        => new RecordService(name);

    public static ICommandService GetControllerService(string name)
        => new ControllerService(name);

    public static ICommandService GetMinimalApiService(string name)
        => new MinimalApiService(name);
    public static ICommandService GetValidatorService(string name)
        => new ValidatorService(name);

    public static ICommandService GetRequestService(string name, string response, string directory = "")
        => new RequestService(name, response, directory);
    
    public static ICommandService GetHandlerService(string name, string response, string directory = "")
        => new HandlerService(name, response, directory);
    
}
