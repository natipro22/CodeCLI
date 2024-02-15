using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.DirectoryNamespace;

namespace Code.Commands.Generate;

public static class Content
{
    public static string Class(string name)
        => $"namespace {Namespace.GetNamespace()};\npublic class {name}\n{{\n    \n}}";

    public static string Interface(string name, char prefix)
        => $"namespace {Namespace.GetNamespace()};\npublic interface {(prefix == ' ' ? "" : prefix)}{name}\n{{\n   \n}}";

}
