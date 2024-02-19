using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Code.DirectoryNamespace;
public class Namespace
{
    public static string GetProjectDirectory()
    {
        // Get the currently executing assembly
        Assembly assembly = Assembly.GetEntryAssembly()!;
        // Get the directory of the assembly
        string assemblyLocation = assembly.Location;
        string projectDirectory = Directory.GetParent(assemblyLocation)?.Parent?.Parent?.Parent?.FullName!;

        return projectDirectory;
    }

    public static string GetNamespace(string newDirectory = "", string? directory = null)
    {
        directory ??= GetProjectDirectory();
        // Get the name of the current directory
        string directoryName = new DirectoryInfo(directory).Name;
        // Initialize the namespace with the current directory name
        string @namespace = directoryName;
        if (directory == Directory.GetCurrentDirectory() && string.IsNullOrEmpty(newDirectory))
        {
            return @namespace;
        }
        throw new Exception(directory);
        Console.WriteLine(directory);
        // Get the subdirectories of the current directory
        string[] subdirectories = (Directory.GetCurrentDirectory() + "/" + newDirectory)
            .Substring(directory.Length + 1)
            .Split('\\', '/');

        // If there are subdirectories, recursively get directory name for each subdirectory
        if (subdirectories.Length > 0)
        {
            foreach (string subdirectory in subdirectories.Where(d => !string.IsNullOrEmpty(d)))
            {
                string subNamespace = new DirectoryInfo(subdirectory).Name;

                // Append the subnamespace to the current namespace
                @namespace = $"{@namespace}.{subNamespace}";
            }
        }

        return @namespace;
    }
}
