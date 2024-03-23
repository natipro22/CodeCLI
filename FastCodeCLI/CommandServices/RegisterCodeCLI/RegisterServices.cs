using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace CodeCLI.CommandServices.RegisterCodeCLI;
public class RegisterServices
{
    public static void RegisterToAspNetProgram()
    {
        string fileName = "Program.cs"; // Specify the path to your Program.cs file
        string filePath = fileName.GetFileDirectory();

        var path = Path.Combine(filePath, fileName);

        // Define the pattern to search for builder.Run()
        string buildPattern = @"var app = builder\.Build\(\s*\);";

        // Define the replacement line
        string buildReplacement = "builder.Services.AddCodeCLIServices();\nvar app = builder.Build();";

        // Perform the replacement
        fileName.Replace(path, buildPattern, buildReplacement);

        // Define the pattern to search for builder.Run()
        string runPattern = @"app\.Run\(\s*\);";

        // Define the replacement line
        string runReplacement = "app.UseCodeCLIServices();\napp.Run();";

        // Perform the replacement
        fileName.Replace(path, runPattern, runReplacement);
    }

    private static string CreateStartup()
    {
        string fileName = "Program.cs"; // Specify the path to your Program.cs file

        string filePath = fileName.GetFileDirectory();
        var path = Path.Combine(filePath, "CodeCLIStartup.cs");

        string name = "codeCLIStartupTemp.txt";
        string content = CommandService.ReadFile(name);

        content = content.Replace(nameof(Namespace).ToVar(), Namespace.GetNamespace());

        File.WriteAllText(path, content);

        RegisterToAspNetProgram();
        return filePath;
    }

    public static void RegisterMiddleware(string name)
    {
        string fileName = "CodeCLIStartup.cs"; // Specify the path to your Program.cs file
        string filePath;
        try
        {
            filePath = fileName.GetFileDirectory();
        }
        catch (FileNotFoundException)
        {
            filePath = CreateStartup();
        }

        var path = Path.Combine(filePath, fileName);

        // Define the pattern to search for builder.Run()
        string buildPattern = "\t\treturn services;";

        // Define the replacement line
        string buildReplacement = $"\t\tservices.AddTransient<{name}Middleware>();\n{buildPattern}";

        // Perform the replacement
        fileName.Replace(path, buildPattern, buildReplacement);

        // Define the pattern to search for builder.Run()
        string appPattern = "\t\treturn builder;";

        // Define the replacement line
        string appReplacement = $"\t\tbuilder.UseMiddleware<{name}Middleware>();\n{appPattern}";

        // Perform the replacement
        fileName.Replace(path, appPattern, appReplacement);

    }
}
