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
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Get the directory of the assembly
        string assemblyLocation = assembly.Location;

        // Get the directory containing the assembly (project directory)
        string projectDirectory = Path.GetDirectoryName(assemblyLocation);

        return projectDirectory;
    }

    public static string GetNamespace(string? directory = null)
    {
        directory ??= GetProjectDirectory();
        // Get the name of the current directory
        string directoryName = new DirectoryInfo(directory).Name;

        // Initialize the namespace with the current directory name
        string @namespace = directoryName;

        // Get the subdirectories of the current directory
        string[] subdirectories = Directory.GetDirectories(directory);

        // If there are subdirectories, recursively call GetNamespace for each subdirectory
        if (subdirectories.Length > 0)
        {
            foreach (string subdirectory in subdirectories)
            {
                string subNamespace = GetNamespace(subdirectory);

                // Append the subnamespace to the current namespace
                @namespace = $"{@namespace}.{subNamespace}";
            }
        }

        return @namespace;
    }
}
