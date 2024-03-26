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

        // Perform the replacement
        programFile.Replace(path, runPattern, runReplacement);
    }

    private static string CreateStartup()
    {
        string filePath = programFile.GetFileDirectory();
        var path = Path.Combine(filePath, configFile);

        string name = "codeCLIStartupTemp.txt";
        string content = CommandService.ReadFile(name);

        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace());

        File.WriteAllText(path, content);

        RegisterToAspNetProgram();
        return filePath;
    }

    private static string GetStartup()
    {
        string configPath;
        try
        {
            configPath = configFile.GetFileDirectory();
        }
        catch (FileNotFoundException)
        {
            configPath = CreateStartup();
        }
        return configPath;
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
        var path = Path.Combine(GetStartup(), configFile);

        // Define the replacement line
        string replacement = $"\t\tservices.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Transient);\n{build}";

        string usings = """
            using FluentValidation.AspNetCore;
            using System.Reflection;
            """;
        // Perform the replacement
        configFile.Replace(path, build, replacement, usings);
    }


}
