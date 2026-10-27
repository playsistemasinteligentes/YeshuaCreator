namespace Repositorio.Outputs;

public partial record yOutboxDTO
{
    // Claim projection only. This is not a persisted column.
    public int claimpreviousstatus { get; set; }
}
