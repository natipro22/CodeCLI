using CodeCLI.Common;
using CodeCLI.DirectoryNamespace;

namespace CodeCLI.Commands.Generate;

public static class Content
{
    public static string Class(string name, bool isAbstract)
        => $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public {(isAbstract ? "abstract" : string.Empty)} class {name}\n{{\n    \n}}";
    public static string Enum(string name)
        => $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public enum {name}\n{{\n   \n}}";
    public static string Controller(string name)
        => $"using Microsoft.AspNetCore.Mvc;\n\n" +
            $"namespace {Namespace.GetNamespace()};\n\n" +
            "[ApiController]\n" +
            "[Route(\"[controller]\")]\n" +
            $"public class {name}Controller : ControllerBase\n" +
            "{\n" +
            "\t[HttpGet]\n" +
            "\tpublic IActionResult GetAll()\n" +
            "\t{\n  \t\treturn Ok(default);\n\t}\n" +
            "\t[HttpGet(\"{id}\")]\n" +
            "\tpublic IActionResult GetById(Guid id)\n" +
            "\t{\n  \t\treturn Ok(default);\n\t}\n" +
            "\t[HttpPost]\n" +
            "\tpublic IActionResult Create([FromBody] string userInput)\n" +
            "\t{\n  \t\treturn Ok(default);\n\t}\n" +
            "\t[HttpPut(\"{id}\")]\n" +
            "\tpublic IActionResult Update([FromQuery] Guid id, [FromBody] string userInput)\n" +
            "\t{\n  \t\treturn Ok(default);\n\t}\n" +
            "\t[HttpDelete(\"{id}\")]\n" +
            "\tpublic IActionResult Delete([FromQuery] Guid id)\n" +
            "\t{\n  \t\treturn Ok(default);\n\t}\n" +
            "}";
    public static string Handler(string name, string response)
        => $"using MediatR;\n\n" +
            $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public class {name}Handler : IRequestHandler<{name}, {response}>\n" +
            "{\n" +
            $"\tpublic async Task<{response}> Handle({name} request, CancellationToken cancellationToken)\n" +
            "\t{\n" +
            $"\t\treturn new {response}();\n" +
            "\t}\n" +
            "}";
    public static string Interface(string name, char prefix)
        => $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public interface {(prefix == ' ' ? "" : prefix)}{name}\n{{\n   \n}}";
    public static string MinimalApi(string name)
        => "using Microsoft.AspNetCore.Builder;\n" +
            $"using Microsoft.AspNetCore.Mvc;\n\n" +
            $"namespace {Namespace.GetNamespace()};\n" +
            $"public static void Map{name}Endpoints(this WebApplication app)\n" +
            "{\n" +
            "\t//Create\n" +
            $"\tapp.MapPost(\"/{name}s\",async ({name}Request {name.ToCamelCase()}Request, I{name}Service {name.ToCamelCase()}Service)\n" +
            $"\t\t => await {name.ToCamelCase()}Service.Create{name}({name.ToCamelCase()}Request));\n\n" +
            "\t//Read All\n" +
            $"\tapp.MapGet(\"/{name}\", async (I{name}Service {name.ToCamelCase()}Service)\n" +
            $"\t\t => await {name.ToCamelCase()}Service.Get{name}s());\n\n" +
            "\t//Read by Id\n" +
            $"\tapp.MapGet(\"/{name}/{{id}}\", async (Guid id, I{name}Service {name.ToCamelCase()}Service) \n" +
            $"\t\t => await {name.ToCamelCase()}Service.Get{name}ById(id));\r\n\n\n" +
            "\t//Update\n" +
            $"\tapp.MapPut(\"/{name}s/{{id}}\", async (Guid id, {name}Request {name.ToCamelCase()}Request, I{name}Service {name.ToCamelCase()}Service)\n" +
            $"\t\t => await {name.ToCamelCase()}Service.Update{name}(id, {name.ToCamelCase()}Request));\n\n" +
            "\t//Delete\n" +
            $"\tapp.MapDelete(\"/{name}s/{{id}}\", async (Guid id, I{name}Service {name.ToCamelCase()}Service)\n" +
            $"\t\t => await {name.ToCamelCase()}Service.Delete{name}(id));\n\n" +
            "}";
    public static string Record(string name)
        => $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public record {name}(string Property)\n{{\n   \n}}";
    public static string REPR(string name)
        => $"namespace {Namespace.GetNamespace()};\n\npublic interface {name}\n{{\n   \n}}";
    public static string Request(string name, string response)
        => $"using MediatR;\n\n" +
            $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public record {name}(string Property) : IRequest<{response}>\n" +
            "{\n" +
            "}";
    public static string Service(string name, string extends, IEnumerable<string> implements)
        => $"namespace {Namespace.GetNamespace()};\n\n" +
            $"public class {name}Service" +
            $"{(string.IsNullOrEmpty(extends) && implements == Enumerable.Empty<string>() ? "" : " : ")}{extends.Trim()}" + 
            $"{(implements == Enumerable.Empty<string>() ? "" : ", ")}{string.Join(", ", implements).Trim()}\n{{\n   \n}}";

    public static string Validator(string name)
        => $"using FluentValidation;\n\n" +
            $"namespace {Namespace.GetNamespace()};\n\n" +
            "public class {name}Validator : AbstractValidator<{name}>\n{{\n   \n}}";
}
