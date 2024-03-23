using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCLI.CommandServices;
public class MiddlewareService : CommandService
{
    protected override string GetContent()
    {
        var name = "middlewareTemp.txt";
        string content = ReadFile(name);

        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), Name);

        return content;
    }
}
