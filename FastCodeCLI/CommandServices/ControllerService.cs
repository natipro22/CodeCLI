using Code.DirectoryNamespace;

namespace Code.CommandServices;

public class ControllerService : ClassService, ICommandService
{
    private static readonly string Extends = "BaseController";
    private static readonly string GetAllMethod = 
    @"	[HttpGet]
	public IActionResult GetAll()
	{
  		return Ok(default);
	}";

    private static readonly string GetByIdMethod =
    @"	[HttpGet(""{id}"")]
	public IActionResult GetById(Guid id)
	{
  		return Ok(default);
	}";

    private static readonly string CreateMethod =
    @"	[HttpPost]
	public IActionResult Create([FromBody] string userInput)
	{
  		return Ok(default);
	}";

    private static readonly string UpdateMethod =
    @"	[HttpPut(""{id}"")]
	public IActionResult Update([FromQuery] Guid id, [FromBody] string userInput)
	{
  		return Ok(default);
	}";
    
    private static readonly string DeleteMethod =
    $@"	[HttpDelete(""{{id}}"")]
	public IActionResult Delete([FromQuery] Guid id)
	{{
  		return Ok(default);
	}}";

    private static readonly List<string> attributes = new List<string> { "[ApiController]", "[Route(\"[controller]\")]" };
    private static readonly List<string> usings = new List<string> { "using Microsoft.AspNetCore.Mvc;" };

    public ControllerService(string name, string path)
    : base($"{name}Controller",
           usings,
           Extends,
           attributes,
           GetAllMethod,
           GetByIdMethod,
           CreateMethod,
           UpdateMethod,
           DeleteMethod)
    {
        _directory = path;
    }
}
