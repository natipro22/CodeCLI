﻿using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace Code.Commands;
[Command]
public abstract class BaseCommand : ICommand
{

    protected string _fileName = string.Empty;

    [CommandOption("path", 'p', Description = "The path of the file.")]
    public string? Path { get; set; } = string.Empty;

    public abstract ValueTask ExecuteAsync(IConsole console);
    
}

