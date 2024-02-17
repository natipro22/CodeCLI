using Code.DirectoryNamespace;

namespace Code.CommandServices;

public class EnumService : CommandService, ICommandService
{
    public EnumService(string name) : base(name, fileName: $"{name}.cs")
    {
    }

    protected override string GetContent()
        => $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public enum {_name}\n{{\n   \n}}";
}
