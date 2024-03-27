using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;

namespace CodeCLI.CommandServices;

public class InterfaceService : CommandService, ICommandService
{
    public IEnumerable<string> Extends { get; set; }
    public char Prefix { get; set; } = 'I';
    
    protected override string GetContent()
    {
        string name = "interfaceTemp.txt";
        string content = ReadFile(name);

        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(Directory));
        content = content.Replace(nameof(Name).ToVar(), $"{(Prefix.Equals(' ') ? string.Empty : Prefix)}{Name}");
        string Inheritance = string.Empty;
        if (Extends.Any())
        {
            Inheritance += " : ";
            Inheritance += string.Join(", ", Extends).Trim();
        }
        content = content.Replace(nameof(Inheritance).ToVar(), Inheritance);
        return content;
    }
}
