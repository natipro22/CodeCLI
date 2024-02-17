
namespace Code.CommandServices;

public class ValidatorService : ClassService, ICommandService
{
    private static readonly IEnumerable<string> usings = new List<string> { "using FluentValidation;" };
    public ValidatorService(string name)
        : base($"{name}Validator", $"AbstractValidator<{name}>", Enumerable.Empty<string>(), usings)
    {
    }
}
