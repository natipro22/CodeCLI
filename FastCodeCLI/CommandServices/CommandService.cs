using Code.Common;

namespace Code.CommandServices;

public abstract class CommandService : ICommandService
{
    protected readonly string _name = string.Empty;
    protected string _variableName = string.Empty;
    protected readonly string _fileName = string.Empty;
    protected string _directory = string.Empty;
    public CommandService(string name, string fileName)
    {
        _name = name;
        _fileName = fileName;
        _variableName = name.ToCamelCase();
    }

    public CommandService(string name, string fileName, string directory)
        : this(name, fileName)
        => _directory = directory;

    public string CreateFile()
    {
        File.WriteAllText(!string.IsNullOrEmpty(_directory) ? _directory + "/" + _fileName : _fileName, GetContent());
        return _fileName;
    }
    protected abstract string GetContent();

}
