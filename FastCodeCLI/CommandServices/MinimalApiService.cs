
using Code.Common;

namespace Code.CommandServices;

public class MinimalApiService : ClassService, ICommandService
{
    private static readonly List<string> usings = new List<string> { "using Microsoft.AspNetCore.Builder;", "using Microsoft.AspNetCore.Mvc;" };
    public MinimalApiService(string name)
    : base($"{name}Api", usings, string.Empty)
    {
        _variableName = name.ToCamelCase();
        _body = 
    $@"	public static void Map{name}Endpoints(this WebApplication app)
    {{
        //Create
        app.MapPost(""/{name}s"",async ({name}Request {_variableName}Request, I{name}Service {_variableName}Service)
            => await {_variableName}Service.Create{name}({_variableName}Request));
		//Read All
        app.MapGet(""/{name}"", async (I{name}Service {_variableName}Service)
            => await {_variableName}Service.Get{name}s());
        //Read by Id
        app.MapGet(""/{name}/{{id}}"", async (Guid id, I{name}Service {_variableName}Service) 
            => await {_variableName}Service.Get{name}ById(id));
        //Update
        app.MapPut(""/{name}s/{{id}}"", async (Guid id, {name}Request {_variableName}Request, I{name}Service {_variableName}Service)
            => await {_variableName}Service.Update{name}(id, {_variableName}Request));
        //Delete
        app.MapDelete(""/{name}s/{{id}}"", async (Guid id, I{name}Service {_variableName}Service)
            => await {_variableName}Service.Delete{name}(id));
    }}";
    }
}
