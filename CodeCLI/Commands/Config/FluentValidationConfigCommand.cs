﻿using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Install;
using CodeCLI.CommandServices.RegisterCodeCLI;

namespace CodeCLI.Commands.Config;
[Command("config fluent-validation", "(config|c) (fluent-validation|fv)$", Description = "Register FluentValidation library to the project.")]
public class FluentValidationConfigCommand : ICommand
{
    public ValueTask ExecuteAsync(IConsole console)
    {
        try
        {
            ICommand installCommand = new InstallFluentValidationCommand();
            installCommand.ExecuteAsync(console);
        }
        catch (Exception e)
        {
            console.Error.WriteLine("Falild to install FluentValidation library.");
            console.Error.WriteLine($"Please try again.{e.Message}");
        }

        try
        {
            RegisterServices.RegisterFluentValidation();

            console.WriteLine("Fluent validation registerd successfully.");
        }
        catch (FileNotFoundException)
        {
            console.Error.WriteLine("Error: file not found.");
        }
        catch (Exception ex)
        {
            console.Error.WriteLine($"An error occurred: {ex.Message}");
        }
        return ValueTask.CompletedTask;
    }
}