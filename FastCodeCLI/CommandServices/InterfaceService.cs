using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.DirectoryNamespace;

namespace Code.CommandServices;

public class InterfaceService : CommandService, ICommandService
{
    private readonly char _prefix;
    
    public InterfaceService(string name, char prefix) : base(name, fileName: $"{prefix}{name}.cs")
    {
        _prefix = prefix;
    }

    public InterfaceService(string name, char prefix, string path)
        : this(name, prefix)
    {
        _directory = path;
    }

    protected override string GetContent()
        => $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public interface {(_prefix == ' ' ? string.Empty: _prefix)}{_name}\n{{\n   \n}}";
}
