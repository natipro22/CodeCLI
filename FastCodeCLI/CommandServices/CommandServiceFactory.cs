using System.Text.Json;
using System.Xml.Linq;

namespace Code.CommandServices;

public static class CommandServiceFactory
{
    public static ICommandService GetClassService(string name, string extends, IEnumerable<string> implements, bool isAbstract, bool isSeald, string path)
        => new ClassService
        {
            Name = name,
            IsAbstract = isAbstract,
            IsSeald = isSeald,
            Extends = extends,
            Implements = implements,
            Directory = path,
        };

    public static ICommandService GetInterfaceService(string name, char prefix, string path)
        => new InterfaceService
        {
            FileName = $"{(prefix.Equals(' ') ? string.Empty : prefix)}{name}",
            Name = name,
            Prefix = prefix,
            Directory = path
        };

    public static ICommandService GetEnumService(string name, string path)
        => new EnumService
        {
            Name = name,
            Directory = path
        };

    public static ICommandService GetRecordService(string name, string extends, IEnumerable<string> implements, string path)
        => new RecordService
        {
            Name = name,
            Extends = extends,
            Implements = implements,
            Directory = path
        };

    public static ICommandService GetControllerService(string name, string path)
        => new ControllerService
        {
            FileName = $"{name}Controller",
            Name = name,
            Directory = path
        };

    public static ICommandService GetMinimalApiService(string name, string path)
        => new MinimalApiService
        {
            FileName = $"{name}Endpoints",
            Name = name,
            Directory = path
        };
    public static ICommandService GetValidatorService(string name, string path)
        => new ValidatorService
        {
            FileName = $"{name}Validator",
            Name = name,
            Directory = path
        };

    public static ICommandService GetRequestService(string name, string response, string path)
        => new RequestService
        {
            FileName = $"{name}Request",
            Name = name,
            Response = response,
            Directory = path
        };
    
    public static ICommandService GetHandlerService(string name, string response, string path)
        => new HandlerService
        {
            FileName = $"{name}RequestHandler",
            Name = name,
            Response = response,
            Directory = path
        };
    
}
