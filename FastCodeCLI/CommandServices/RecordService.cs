using Code.DirectoryNamespace;

namespace Code.CommandServices;

public class RecordService : CommandService, ICommandService
{
    private readonly string _extends = string.Empty;
    private readonly IEnumerable<string> _implements = Enumerable.Empty<string>();
    private readonly IEnumerable<string> _usings = Enumerable.Empty<string>();
    public RecordService(string name) : base(name, fileName: $"{name}.cs")
    {
    }

    private RecordService(string name, IEnumerable<string> implements)
        : this(name)
        => _implements = implements;

    public RecordService(string name, IEnumerable<string> implements, IEnumerable<string> usings)
        : this(name, implements)
        => _usings = usings;

    protected override string GetContent()
        => $"{string.Join("\n", _usings)}\n\n" +
            $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public record {_name}(string Property)" +
            $"{(string.IsNullOrEmpty(_extends) && _implements == Enumerable.Empty<string>() ? string.Empty : " : ")}{_extends.Trim()}" + 
            $"{(string.IsNullOrEmpty(_extends) || _implements == Enumerable.Empty<string>() ? string.Empty : ", ")}{string.Join(", ", _implements).Trim()}\n" +
            "{\n\t\n}";
}