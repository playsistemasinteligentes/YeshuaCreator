namespace Command.UseCase;

public partial record LoginOutputCommand
{
    public List<string> catalogos { get; set; } = new();
}
