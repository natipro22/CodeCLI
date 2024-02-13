using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Code.DirectoryNamespace;

namespace FastCodeCLI.commands.generate;

public static class Content
{
    public static string Class(string className)
        => $"namespace {Namespace.GetNamespace()};\npublic class {className}\n{{\n    \n}}";

}
