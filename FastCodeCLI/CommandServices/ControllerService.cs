using Code.DirectoryNamespace;

namespace Code.CommandServices;

public class ControllerService : CommandService, ICommandService
{
    public ControllerService(string name)
        : base(name, fileName: $"{name}Controller.cs")
    {

    }

    protected override string GetContent()
        => $"using Microsoft.AspNetCore.Mvc;\n\n" +
            $"namespace {Namespace.GetNamespace()};\n\n" +
            "[ApiController]\n" +
            "[Route(\"[controller]\")]\n" +
            $"public class {_name}Controller : ControllerBase\n" +
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
}
