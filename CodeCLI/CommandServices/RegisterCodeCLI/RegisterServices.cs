using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CodeCLI.CommandServices.RegisterCodeCLI;
public class RegisterServices
{
    private static string configFile = "CodeCLIStartup.cs";
    private static string programFile = "Program.cs";

    private static string build = "\t\treturn services;";
    private static string app = "\t\treturn builder;";
    public static void RegisterToAspNetProgram()
    {
        string filePath = programFile.GetFileDirectory();

        var path = Path.Combine(filePath, programFile);

        // Define the pattern to search for builder.Run()
        string buildPattern = @"var app = builder\.Build\(\s*\);";

        // Define the replacement line
        string buildReplacement = "builder.Services.AddCodeCLIServices();\nvar app = builder.Build();";

        // Perform the replacement
        programFile.Replace(path, buildPattern, buildReplacement);

        // Define the pattern to search for builder.Run()
        string runPattern = @"app\.Run\(\s*\);";

        // Define the replacement line
        string runReplacement = "app.UseCodeCLIServices();\napp.Run();";
        var usings = $"using {Namespace.GetNamespace(string.Empty, filePath)};";
        // Perform the replacement
        programFile.Replace(path, runPattern, runReplacement, usings);
    }

    private static string CreateStartup()
    {
        string filePath = programFile.GetFileDirectory();
        var path = Path.Combine(filePath, configFile);
        Console.WriteLine("CreateStartup: " + path);

        string name = "codeCLIStartupTemp.txt";
        string content = CommandService.ReadFile(name);

        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace(string.Empty, filePath));

        File.WriteAllText(path, content);

        RegisterToAspNetProgram();
        return filePath;
    }

    private static string GetStartup()
    {
        try
        {
            return configFile.GetFileDirectory();
        }
        catch (FileNotFoundException)
        {
            return CreateStartup();
        }
    }

    public static void RegisterMiddleware(string name)
    {
        var path = Path.Combine(GetStartup(), configFile);

        // Define the replacement line
        string buildReplacement = $"\t\tservices.AddTransient<{name}Middleware>();\n{build}";

        // Perform the replacement
        configFile.Replace(path, build, buildReplacement);

        // Define the replacement line
        string appReplacement = $"\t\tbuilder.UseMiddleware<{name}Middleware>();\n{app}";

        // Perform the replacement
        configFile.Replace(path, app, appReplacement);

    }

    public static void RegisterMediatR()
    {
        var path = Path.Combine(GetStartup(), configFile);

        // Define the replacement line
        string replacement = $"\t\tservices.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));\n{build}";
        string usings = "using MediatR;";
        // Perform the replacement
        configFile.Replace(path, build, replacement, usings);
    }

    public static void RegisterFluentValidation()
    {
        var startup = GetStartup();
        Console.WriteLine($"startup: {startup}");
        var path = Path.Combine(startup, configFile);

        // Define the replacement line
        string replacement = $"\t\tservices.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient);\n{build}";

        string usings = "using FluentValidation;\nusing System.Reflection;";
        // Perform the replacement
        configFile.Replace(path, build, replacement, usings);
    }

    public static void RegisterCarter()
    {
        var path = Path.Combine(GetStartup(), configFile);

        // Define the replacement line
        string replacement = $"\t\tservices.AddCarter();\n{build}";
        string usings = "using Carter;";
        // Perform the replacement
        configFile.Replace(path, build, replacement, usings);

        // Define the replacement line
        string appReplacement = $"\t\tbuilder.MapCarter();\n{app}";

        // Perform the replacement
        configFile.Replace(path, app, appReplacement);
    }
}
