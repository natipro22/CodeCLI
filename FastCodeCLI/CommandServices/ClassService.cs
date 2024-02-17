using Code.DirectoryNamespace;
using System.Text.Json;

namespace Code.CommandServices;

public class ClassService : CommandService, ICommandService
{
    private readonly string _extends = string.Empty;
    private readonly IEnumerable<string> _implements = Enumerable.Empty<string>();
    private readonly bool _isAbstract = false;
    private readonly IEnumerable<string> _usings = Enumerable.Empty<string>();
    protected string _body = string.Empty;

    public ClassService(string name)
        : base(name, fileName: $"{name}.cs")
    {
    }

    public ClassService(string name, string extends)
        : base(name, fileName: $"{name}.cs")
    {
        _extends = extends;
    }

    public ClassService(string name, IEnumerable<string> implements)
        : this(name)
    {
        _implements = implements;
    }

    public ClassService(string name, IEnumerable<string> implements, IEnumerable<string> usings)
        : this(name, implements)
    {
        _usings = usings;
    }

    public ClassService(string name, string extends, IEnumerable<string> implements)
        : this(name, extends)
    {
        _implements = implements;
    }

    public ClassService(string name, string extends, IEnumerable<string> implements, bool isAbstract)
        : this(name, extends, implements)
    {
        _isAbstract = isAbstract;
    }

    public ClassService(string name, string extends, IEnumerable<string> implements, bool isAbstract, IEnumerable<string> usings)
        : this(name, extends, implements, isAbstract)
    {
        _usings = usings;
    }

    public ClassService(string name, string extends, IEnumerable<string> implements, IEnumerable<string> usings)
        : this(name, extends, implements)
    {
        _usings = usings;
    }

    public ClassService(string name, IEnumerable<string> implements, IEnumerable<string> usings, params string[] body)
        : this(name, implements, usings)
    {
        _body = string.Join("\n\n", body);
    }

    public ClassService(string name, string extends, IEnumerable<string> usings, params string[] body)
        : this(name, extends, usings)
    {
        _body = string.Join("\n\n", body);
    }

    protected override string GetContent()
        => $"{string.Join("\n", _usings)}\n\n" +
            $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public{(_isAbstract ? " abstract" : string.Empty)} class {_name}" +
            $"{(string.IsNullOrEmpty(_extends) && _implements == Enumerable.Empty<string>() ? string.Empty : " : ")}{_extends.Trim()}" + 
            $"{(string.IsNullOrEmpty(_extends) || _implements == Enumerable.Empty<string>() ? string.Empty : ", ")}{string.Join(", ", _implements).Trim()}\n" +
            $"{{\n{_body}\n}}";
}
