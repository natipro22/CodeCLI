using Code.Common;

namespace Code.CommandServices;

public abstract class CommandService : ICommandService
{
    protected readonly string _name = string.Empty;
    protected readonly string _variableName = string.Empty;
    protected readonly string _fileName = string.Empty;
    public CommandService(string name, string fileName)
    {
        _name = name;
        _fileName = fileName;
        _variableName = name.ToCamelCase();
    }

    public string CreateFile()
    {
        File.WriteAllText(_fileName, GetContent());
        return _fileName;
    }
    protected abstract string GetContent();

}
