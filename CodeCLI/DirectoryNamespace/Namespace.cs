namespace CodeCLI.DirectoryNamespace;
public class Namespace
{
    public static string GetProjectDirectory(string? directory = null)
    {
        directory ??= Directory.GetCurrentDirectory();

        string[] csprojFiles = Directory.GetFiles(directory, "*.csproj");

        if (csprojFiles.Length > 0)
            return directory;
        string parentDirectory = Directory.GetParent(directory)?.FullName!;
        if (parentDirectory is not null && parentDirectory != directory)
        {
            return GetProjectDirectory(parentDirectory);
        }

        throw new FileNotFoundException("No poject file (.csproj) found.");
    }

    public static string GetNamespace(string newDirectory = "", string? directory = null)
    {
        var projectDirectory = GetProjectDirectory();
        directory ??= Directory.GetCurrentDirectory();
        // Get the name of the current directory
        string directoryName = new DirectoryInfo(projectDirectory).Name;
        // Initialize the namespace with the current directory name
        string @namespace = directoryName;
        if (projectDirectory == directory && string.IsNullOrEmpty(newDirectory))
        {
            return @namespace;
        }
        // Get the subdirectories of the current directory
        string[] subdirectories = Path.Combine(directory, newDirectory)
            .Substring(projectDirectory.Length + 1)
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
