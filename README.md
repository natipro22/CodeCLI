# CodeCLI
## Introduction
The Code CLI is a simple command-line interface tool that you use to initialize, develop, scaffold, and maintain dotnet C# applications directly from a command shell.

## Installation 
Using the .net core CLI from a terminal window:
```
dotnet tool install --global CodeCLI
```
> Note: restart your IDE after installation.
## Usage 
Invoke the tool on the command line through the `dotnet code` executable.

## Open dotnet solution in Visual Studio
```
dotnet code .
```
## Help 
``` dotnet code --help ```

## Commands

+ code
	- generate (g)
	- install (i)
	- config (c)

## Generate Command 
Generates and/or modifies files based on a schematic.
```
dotnet code generate --help
```
or 
```
dotnet code g -h
```

### Generate Sub Commands 
`dotnet code genarate` or `dotnet code g` 
+ C#
  - Class (c)
  - Interface (i)
  - Record (r)
  - Enum (e)
  - Service (s)
+ ASP.NET 
  - Controller (cvt)
  - Minimal Api (ma)
  - Middleware (mw)
+ Vertical slice (repr)
+ MediatR (m)
  - Request (r)
  - Handler (h)
  - Notification (n)
  - Notification Handler (nh)
+ Fluent Validation (fv)
  - Validator (v)

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





