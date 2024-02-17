using System.Text.Json;
using System.Xml.Linq;

namespace Code.CommandServices;

public static class CommandServiceFactory
{
    public static ICommandService GetClassService(string name, object props)
    {
        string propString = JsonSerializer.Serialize(props);
        return new ClassService(name, propString);
    }
}
