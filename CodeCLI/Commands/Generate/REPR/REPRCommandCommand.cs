﻿using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using CodeCLI.Commands.Generate;
using CodeCLI.CommandServices;
using CodeCLI.CommandServices.MediatR;
using CodeCLI.Common;
using Humanizer;
using System.Xml.Linq;

namespace CodeCLI.Commands.Generate.REPR;
[Command("generate repr command", "(generate|g) (repr) (command|c)$")]
public class REPRCommandCommand : BaseCommand
{
    [CommandParameter(0, IsRequired = true, Description = "The name of the REPR")]
    public string Name { get; set; } = string.Empty;

    public override ValueTask ExecuteAsync(IConsole console)
    {
        if (string.IsNullOrEmpty(Path))
        {
            Path = Name;
        }
        string response = $"{Name}ResponseDto";
        ICommandService request = CommandServiceFactory.GetRequestService(Name, response, CQRS.Command, Path);
        ICommandService handler = CommandServiceFactory.GetHandlerService(Name, response, CQRS.Command, Path);
        ICommandService validator = CommandServiceFactory.GetValidatorService($"{Name}{nameof(CQRS.Command)}", Path);
        ICommandService endpoint = CommandServiceFactory.GetEndpointService(Name, Path);
        ICommandService recordService = CommandServiceFactory.GetRecordService(response, string.Empty, Enumerable.Empty<string>(), Path);


        try
        {
            request.CreateFile();
            handler.CreateFile();
            validator.CreateFile();
            endpoint.CreateFile();
            recordService.CreateFile();
            console.Output.WriteLine($"{Name} feature created succesfully.");
        }
        catch (Exception e)
        {
            console.Error.WriteLine(e.Message);
        }
        
        return ValueTask.CompletedTask;

    }
}
