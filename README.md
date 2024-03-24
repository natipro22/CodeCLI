# CodeCLI
## Introduction
The Code CLI is a simple command-line interface tool that you use to initialize, develop, scaffold, and maintain dotnet C# applications directly from a command shell.

## Installation 
Using the .net core CLI from a terminal window:
```
dotnet tool install --global CodeCLI
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

## Commands

+ code
	- generate
	- install
	- config


## Generate Sub Commands 
+ C#
  - Class (c)
  - Interface (i)
  - Record (r)
  - Enum (e)
  - Service (s)
+ ASP.NET 
  - Controller (ct)
  - Minimal Api (ma)
  - Middleware (mw)
+ MediatR (m)
  - Request (r)
  - Handler (h)
  - Notification (n)
  - Notification Handler (nh)
+ Fluent Validation (fv)
  - Validator (v)
+ Vertical slice (repr)

### Install Sub Commands
`dotnet code install` or `dotnet code i` add packages to the ASP.NET Core Project
+ code install (i)
	- MediatR (m)
	- FluentValidation (fv)
### Config Sub Command
`dotnet code config` comamnd registers the dependency to the ASP.NET Project.
+ code config (c)
	- MediatR (m)
	- FluentValidation (fv)
	- Middleware (mw)





