using Code.DirectoryNamespace;

namespace Code.CommandServices;

public class RecordService : CommandService, ICommandService
{
    private readonly string _extends = string.Empty;
    private readonly IEnumerable<string> _implements = Enumerable.Empty<string>();
    private readonly IEnumerable<string> _usings = Enumerable.Empty<string>();
    public RecordService(string name)
        : base(name, fileName: $"{name}.cs")
    {
    }

    public RecordService(string name, string directory)
        : base(name, fileName: $"{name}.cs", directory)
    {
    }

    private RecordService(string name, IEnumerable<string> implements)
        : this(name)
        => _implements = implements;
    
    private RecordService(string name, IEnumerable<string> implements, string directory)
        : this(name, directory)
        => _implements = implements;

    public RecordService(string name, IEnumerable<string> implements, IEnumerable<string> usings)
        : this(name, implements)
        => _usings = usings;
    
    public RecordService(string name, IEnumerable<string> implements, IEnumerable<string> usings, string directory)
        : this(name, implements, directory)
        => _usings = usings;

    protected override string GetContent()
        => $"{string.Join("\n", _usings)}\n\n" +
            $"namespace {Namespace.GetNamespace(_directory)};\n\n" +
            $"public record {_name}(string Property)" +
            $"{(string.IsNullOrEmpty(_extends) && _implements == Enumerable.Empty<string>() ? string.Empty : " : ")}{_extends.Trim()}" + 
            $"{(string.IsNullOrEmpty(_extends) || _implements == Enumerable.Empty<string>() ? string.Empty : ", ")}{string.Join(", ", _implements).Trim()}\n" +
            "{\n\t\n}";
}
