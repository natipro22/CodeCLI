using Code.DirectoryNamespace;
using System.Text.Json;

namespace Code.CommandServices;

public class ClassService : CommandService, ICommandService
{
    private CommandParam? _params;
    public ClassService(string name) : base(name)
    {

    }

    public ClassService(string name, string jsonParam) : base(name)
    {
        _params = ToParam(jsonParam);
    }
    protected override string FileName { get => _name + "Service"; set => base.FileName = _name; }
    private CommandParam ToParam(string jsonString)
    {
        _fileName = $"{_name}.cs";
        return JsonSerializer.Deserialize<CommandParam>(jsonString)!;
    }
    private record CommandParam(string Name, bool IsAbstract);

    protected override string GetContent(string jsonParam)
    {
        _fileName = $"{_name}Service.cs";
        var param = ToParam(jsonParam);
        return $"namespace {Namespace.GetNamespace()};\n\n" +
                $"public {(param.IsAbstract ? "abstract" : string.Empty)} class {param.Name}\n{{\n    \n}}";
    }
}
