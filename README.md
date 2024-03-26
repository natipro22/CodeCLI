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
  - Controller (ct)
  - Minimal Api (ma)
  - Middleware (mw)
+ Vertical slice (repr)
  - command (c)
  - query (q)
+ MediatR (m)
  - command (c)
  - query (q)
  - command-handler (ch)
  - query-handler (qh)
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

## Examples
``` shell
dotnet code g c test-class // generate a class with the name of TestClass
dotnet code g i test-name // generate an interface with the name of test-name
dotnet code g e enum_name // enum
dotnet code g fv v nameValidator // fluent validation validator
```

> Note: You can use any naming convention for the name parameter





