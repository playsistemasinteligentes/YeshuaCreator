namespace Command.UseCase;

public partial record LoginOutputCommand
{
    public List<string> catalogos { get; set; } = new();
    public string tenantIdentity { get; set; } = string.Empty;
    public string tenantDocument { get; set; } = string.Empty;
    public string tenantName { get; set; } = string.Empty;
    public string userIdentity { get; set; } = string.Empty;
    public string userName { get; set; } = string.Empty;
}
