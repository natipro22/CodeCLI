﻿using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Install;
using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeCLI.Commands.Config;
[Command("config mediatr", "(config|c) (mediatr|m)$", Description = "register MediatR library to the project.")]
public class MediatRConfigCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        try
        {
            ICommand installCommand = new InstallMediatRCommand();
            installCommand.ExecuteAsync(console);
        }
        catch (Exception e)
        {
            console.Error.WriteLine("Falild to install MediatR library.");
            console.Error.WriteLine($"Please try again.{e.Message}");
        }

        string fileName = "Program.cs"; // Specify the path to your Program.cs file
        try
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = fileName.GetFileDirectory();

            var path = Path.Combine(filePath, fileName);

            // Read the Program.cs file
            string content = File.ReadAllText(path);

            // Define the pattern to search for builder.Run()
            string pattern = @"var app = builder\.Build\(\s*\);";

            // Define the replacement line
            string replacement = "builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));\nvar app = builder.Build();";

            // Perform the replacement
            string modifiedContent = Regex.Replace(content, pattern, replacement);

            // Write the modified content back to the file
            File.WriteAllText(fileName, modifiedContent);

            console.WriteLine("MediatR registerd successfully.");
        }
        catch (FileNotFoundException)
        {
            console.Error.WriteLine("Error: Program.cs file not found.");
        }
        catch (Exception ex)
        {
            console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
        return ValueTask.CompletedTask;
    }
}