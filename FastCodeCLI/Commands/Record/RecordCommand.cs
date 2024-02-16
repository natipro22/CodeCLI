﻿using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using Code.Common;
using System.Xml.Linq;

namespace Code.Commands.Record;
[Command("generate record", "(generate|g) (record|r)$", Description = "Creates a new, generic record definition in the given project.")]
public class RecordCommand : BaseCommand
{
    private string _name = string.Empty;

    [CommandParameter(0, IsRequired = true, Description = "The name of the record.")]
    public string Name { get => _name; set => _name = value.ToPascalCase(); }

    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Name}.cs";
        File.WriteAllText(name, Content.Record(Name!));
        console.FileCreated(name);
        return ValueTask.CompletedTask;
    }
}
