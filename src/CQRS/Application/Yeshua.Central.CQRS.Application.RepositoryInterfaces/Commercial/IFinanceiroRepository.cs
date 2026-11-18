using Dominio.Commercial;
using Dominio.Commercial.Central;

namespace RepositoryInterfaces.Commercial.Central;

public interface IFinanceiroRepository
{
    FinanceiroSnapshot Read(int tenantId);
    IReadOnlyList<UsageRight> ReadRights(int tenantId);
    IReadOnlyList<CommercialOffer> ReadOffers();
    string CreateCharge(int tenantId, int userId, string requestId, decimal credits);
    void ConfirmSandboxPayment(int tenantId, int userId, string chargeId);
    void Purchase(int tenantId, int userId, string requestId, string offerCode, int quantity);
}

public sealed class FinanceiroSnapshot
{
    public decimal Balance { get; set; }
    public IReadOnlyList<UsageRight> Rights { get; set; } = [];
    public List<FinanceiroMovement> Movements { get; set; } = [];
    public List<FinanceiroCharge> Charges { get; set; } = [];
}
public sealed class FinanceiroMovement
{
    public string Tipo { get; set; } = "";
    public string Referencia { get; set; } = "";
    public decimal Quantidade { get; set; }
    public decimal SaldoApos { get; set; }
    public DateTime CriadoEmUtc { get; set; }
}
public sealed class FinanceiroCharge
{
    public string Id { get; set; } = "";
    public decimal Creditos { get; set; }
    public decimal Valor { get; set; }
    public int Status { get; set; }
    public DateTime VenceEmUtc { get; set; }
}
