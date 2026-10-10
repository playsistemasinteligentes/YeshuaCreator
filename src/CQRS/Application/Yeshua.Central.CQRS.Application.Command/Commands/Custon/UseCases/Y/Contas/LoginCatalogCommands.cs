namespace Command.UseCase;

public partial record LoginOutputCommand
{
    public List<string> catalogos { get; set; } = new();
    public string tenantDocument { get; set; } = string.Empty;
    public string tenantName { get; set; } = string.Empty;
    public string userName { get; set; } = string.Empty;
}
