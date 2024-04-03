using CodeCLI.CommandServices.Blazor;
using CodeCLI.CommandServices.Carter;
using CodeCLI.CommandServices.MediatR;

namespace CodeCLI.CommandServices;

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

    public static ICommandService GetInterfaceService(string name, IEnumerable<string> extends, char prefix, string path)
        => new InterfaceService
        {
            FileName = $"{(prefix.Equals(' ') ? string.Empty : prefix)}{name}",
            Name = name,
            Extends = extends,
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

    public static ICommandService GetRequestService(string name, string response, CQRS type, string path)
        => new RequestService
        {
            FileName = $"{name}{type}",
            Name = name,
            Response = response,
            Directory = path,
            Type = type
        };

    public static ICommandService GetHandlerService(string name, string response, CQRS type, string path)
        => new HandlerService
        {
            FileName = $"{name}{type}Handler",
            Name = name,
            Response = response,
            Directory = path,
            Type = type
        };

    public static ICommandService GetNotificationService(string name, string path)
        => new NotificationService
        {
            FileName = $"{name}Event",
            Name = name,
            Directory = path
        };

    public static ICommandService GetNotificationHandlerService(string name, string path)
        => new NotificationHandlerService
        {
            FileName = $"{name}EventHandler",
            Name = name,
            Directory = path
        };

    public static ICommandService GetMiddlewareService(string name, string path)
        => new MiddlewareService
        {
            FileName = $"{name}Middleware",
            Name = name,
            Directory = path
        };

    public static ICommandService GetRazorService(string name, string path)
        => new RazorService
        {
            Name = name,
            Directory = path,
            Extension = "razor"
        };

    public static ICommandService GetCssService(string name, string path)
        => new CssService
        {
            Name = name,
            Directory = path,
            Extension = "css"
        };

    public static ICommandService GetComponentService(string name, string path)
        => new ComponentService
        {
            FileName = $"{name}.razor",
            Name = name,
            Directory = path,
        };

    public static ICommandService GetEndpointService(string name, string path)
        => new EndpointService
        {
            FileName = $"{name}Endpoint",
            Name = name,
            Directory = path,
        };

}
