using Code.Common;

namespace Code.CommandServices;

public abstract class CommandService : ICommandService
{
    protected string _name = string.Empty;
    protected string _variableName = string.Empty;
    protected string _fileName = string.Empty;
    protected virtual string FileName { get; set; } = string.Empty;
    public CommandService(string name)
    {
        _fileName = _name = name;
        _variableName = name.ToCamelCase();
    }

    public string CreateFile(string name, string jsonParam)
    {
        File.WriteAllText(FileName, GetContent(jsonParam));
        return FileName;
    }
    protected abstract string GetContent(string jsonParam);

}
