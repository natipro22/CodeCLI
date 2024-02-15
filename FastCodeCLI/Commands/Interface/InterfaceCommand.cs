﻿using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Code.Commands.Generate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Commands.Interface;
[Command("generate interface", Description = "Creates a new, generic interface definition in the given project.")]
public class InterfaceCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the interface.")]
    public string Name { get; set; }


    [CommandOption('x', Description = "A prefix to apply to generated selectors.")]
    public char Prefix { get; set; } = 'I';


    public override ValueTask ExecuteAsync(IConsole console)
    {
        string name = $"{Prefix}{Name}.cs";
        File.WriteAllText(name, Content.Interface(Name, Prefix));
        console.Output.WriteLine($"{name} created succesfully.");
        return ValueTask.CompletedTask;
    }
}
