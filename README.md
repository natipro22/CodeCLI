# CodeCLI
## Introduction
The Code CLI is a command-line interface tool that you use to initialize, develop, scaffold, and maintain dotnet C# applications directly from a command shell.

## Installation 
Using the NuGet package manager console within Visual Studio run the following command:
```
Install-Package CodeCLI
```
Or using the .net core CLI from a terminal window:
```
dotnet add package CodeCLI
```

## Usage 
Invoke the tool on the command line through the `dotnet code` executable.

## Open dotnet solution in Visual Studio
```
dotnet code .
```
## Help 
``` dotnet code --help ```

## Generate Command 
Generates and/or modifies files based on a schematic.
```
dotnet code generate --help
```
or 
```
dotnet code g -h
```
##Sub Commands 
+ C#
  - Class
  - Interface
  - Record
  - Enum
  - Service
+ ASP.NET
  - Controller
  - Minimal Api
  - Service Registration
+ MediatR
  - Request
  - Handler
+ Fluent Validation
  - Validator
+ Vertical slice (REPR)




