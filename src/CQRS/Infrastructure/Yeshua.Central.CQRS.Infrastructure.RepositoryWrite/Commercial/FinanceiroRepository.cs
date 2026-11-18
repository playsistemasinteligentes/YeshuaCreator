using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Dominio.Commercial;
using Dominio.Commercial.Central;
using RepositoryInterfaces.Commercial.Central;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Central.Repository.Commercial;

public sealed class FinanceiroRepository(IUnitOfWork work) : IFinanceiroRepository
{
    public FinanceiroSnapshot Read(int tenantId) => new()
    {
        Balance = work.ExecuteScalar<decimal>("SELECT COALESCE((SELECT Saldo FROM CarteiraCredito WHERE Id=CONVERT(varchar(32),@TenantID) AND TenantID=@TenantID AND Deleted=0),0);", new { TenantID = tenantId }),
        Rights = ReadRights(tenantId),
        Movements = work.Query<FinanceiroMovement>(@"SELECT TOP(50) Tipo,Referencia,Quantidade,SaldoApos,CriadoEmUtc
            FROM MovimentoCredito WHERE TenantID=@TenantID AND Deleted=0 ORDER BY CriadoEmUtc DESC,Id;", new { TenantID = tenantId }).ToList(),
        Charges = work.Query<FinanceiroCharge>(@"SELECT TOP(20) Id,Creditos,Valor,Status FROM CobrancaCredito
            WHERE TenantID=@TenantID AND Deleted=0 ORDER BY CriadaEmUtc DESC,Id;", new { TenantID = tenantId }).ToList()
    };

    public IReadOnlyList<UsageRight> ReadRights(int tenantId)
        => work.Query<RightRow>(@"SELECT ResourceKey,PeriodUntilUtc,GrantedUnits FROM DireitoUsoContratado
            WHERE TenantID=@TenantID AND Deleted=0 ORDER BY ResourceKey;", new { TenantID = tenantId })
            .Select(right => new UsageRight(right.ResourceKey,
                right.PeriodUntilUtc.HasValue ? new DateTimeOffset(DateTime.SpecifyKind(right.PeriodUntilUtc.Value, DateTimeKind.Utc)).ToUnixTimeSeconds() : 0,
                right.GrantedUnits)).ToArray();

    public IReadOnlyList<CommercialOffer> ReadOffers()
    {
        var definitions = work.Query<DefinitionRow>(@"SELECT ApplicationKey,DefinitionKey,Description FROM yAuthorizationDefinition
            WHERE DefinitionType='UsageRight' AND Active=1;").ToArray();
        return CommercialOffers.All.Where(offer => definitions.Any(definition =>
        {
            if (definition.ApplicationKey != offer.Application || definition.DefinitionKey != offer.Resource) return false;
            using var document = JsonDocument.Parse(definition.Description);
            var models = document.RootElement.GetProperty("Models").GetInt32();
            return (models & (offer.Model == "period" ? 1 : 2)) != 0;
        })).ToArray();
    }

    public string CreateCharge(int tenantId, int userId, string requestId, decimal credits)
    {
        if (credits is not (50m or 100m or 500m)) throw new ArgumentException("Escolha uma recarga disponivel.");
        var id = RequestKey(tenantId, requestId);
        Atomic(() =>
        {
            LockWallet(tenantId, userId);
            var existing = work.QueryFirstOrDefault<FinanceiroCharge>(@"SELECT Id,Creditos,Valor,Status FROM CobrancaCredito
                WITH(UPDLOCK,HOLDLOCK) WHERE Id=@Id AND TenantID=@TenantID;", new { Id = id, TenantID = tenantId });
            if (existing is not null)
            {
                if (existing.Creditos != credits) throw new InvalidOperationException("Pedido ja utilizado para outra recarga.");
                return;
            }
            work.Execute(@"INSERT INTO CobrancaCredito
                (Id,Creditos,Valor,Status,CriadaEmUtc,VenceEmUtc,Moeda,Provedor,PagaEmUtc,TenantID,UserId,Deleted,Changed,OperationalEntityId)
                VALUES(@Id,@Creditos,@Creditos,0,SYSUTCDATETIME(),DATEADD(day,1,SYSUTCDATETIME()),'BRL','Simulacao',NULL,@TenantID,@UserId,0,SYSUTCDATETIME(),@OperationalEntityId);",
                new { Id = id, Creditos = credits, TenantID = tenantId, UserId = userId, OperationalEntityId = Guid.NewGuid().ToString("N") });
        });
        return id;
    }

    public void ConfirmSandboxPayment(int tenantId, int userId, string chargeId)
    {
        if (string.IsNullOrWhiteSpace(chargeId) || chargeId.Length != 64) throw new ArgumentException("Cobranca invalida.");
        Atomic(() =>
        {
            LockWallet(tenantId, userId);
            var charge = work.QueryFirstOrDefault<FinanceiroCharge>(@"SELECT Id,Creditos,Valor,Status,VenceEmUtc FROM CobrancaCredito
                WITH(UPDLOCK,HOLDLOCK) WHERE Id=@Id AND TenantID=@TenantID AND Deleted=0;", new { Id = chargeId, TenantID = tenantId })
                ?? throw new ArgumentException("Cobranca nao encontrada.");
            if (charge.Status == 1) return;
            if (charge.Status != 0) throw new InvalidOperationException("Cobranca nao aceita pagamento.");
            if (charge.VenceEmUtc <= DateTime.UtcNow) throw new InvalidOperationException("Cobranca vencida. Gere uma nova recarga.");
            work.Execute(@"UPDATE CarteiraCredito SET Saldo=Saldo+@Creditos,Changed=SYSUTCDATETIME() WHERE Id=CONVERT(varchar(32),@TenantID) AND TenantID=@TenantID AND Deleted=0;
                UPDATE CobrancaCredito SET Status=1,PagaEmUtc=SYSUTCDATETIME(),Changed=SYSUTCDATETIME() WHERE Id=@Id AND TenantID=@TenantID;",
                new { Id = chargeId, charge.Creditos, TenantID = tenantId });
            AddMovement(tenantId, userId, "Recarga", chargeId, charge.Creditos);
        });
    }

    public void Purchase(int tenantId, int userId, string requestId, string offerCode, int quantity)
    {
        if (quantity is < 1 or > 36) throw new ArgumentException("Escolha uma quantidade de 1 a 36.");
        var id = RequestKey(tenantId, requestId);
        Atomic(() =>
        {
            LockWallet(tenantId, userId);
            var existing = work.QueryFirstOrDefault<PurchaseRow>(@"SELECT Oferta,Quantidade FROM ContratacaoUso WITH(UPDLOCK,HOLDLOCK)
                WHERE Id=@Id AND TenantID=@TenantID;", new { Id = id, TenantID = tenantId });
            if (existing is not null)
            {
                if (existing.Oferta != offerCode || existing.Quantidade != quantity)
                    throw new InvalidOperationException("Pedido ja utilizado para outra contratacao.");
                return;
            }
            var offer = ReadOffers().SingleOrDefault(offer => offer.Code == offerCode)
                ?? throw new ArgumentException("Oferta indisponivel ou nao declarada na DSL.");
            var total = checked(offer.PriceCredits * quantity);
            var balance = work.ExecuteScalar<decimal>("SELECT Saldo FROM CarteiraCredito WHERE Id=CONVERT(varchar(32),@TenantID) AND TenantID=@TenantID AND Deleted=0;", new { TenantID = tenantId });
            if (balance < total) throw new InvalidOperationException("Creditos insuficientes. Adicione creditos antes de contratar.");
            var rightId = Hash(tenantId + ":" + offer.Resource);
            var right = work.QueryFirstOrDefault<RightRow>(@"SELECT ResourceKey,PeriodUntilUtc,GrantedUnits FROM DireitoUsoContratado WITH(UPDLOCK,HOLDLOCK)
                WHERE Id=@Id AND TenantID=@TenantID;", new { Id = rightId, TenantID = tenantId });
            DateTime? until = offer.Model == "period"
                ? CommercialOffers.ExtendPeriod(right?.PeriodUntilUtc, DateTime.UtcNow, checked(offer.Months * quantity))
                : right?.PeriodUntilUtc;
            var units = (right?.GrantedUnits ?? 0) + offer.Units * quantity;
            work.Execute(@"MERGE DireitoUsoContratado WITH(HOLDLOCK) AS target USING(SELECT @Id AS Id) AS source ON target.Id=source.Id
                WHEN MATCHED AND target.TenantID=@TenantID THEN UPDATE SET PeriodUntilUtc=@Until,GrantedUnits=@Units,Changed=SYSUTCDATETIME()
                WHEN NOT MATCHED THEN INSERT(Id,ResourceKey,PeriodUntilUtc,GrantedUnits,TenantID,UserId,Deleted,Changed,OperationalEntityId)
                    VALUES(@Id,@Resource,@Until,@Units,@TenantID,@UserId,0,SYSUTCDATETIME(),@OperationalEntityId);",
                new { Id = rightId, Resource = offer.Resource, Until = until, Units = units, TenantID = tenantId, UserId = userId, OperationalEntityId = Guid.NewGuid().ToString("N") });
            work.Execute(@"UPDATE CarteiraCredito SET Saldo=Saldo-@Creditos,Changed=SYSUTCDATETIME() WHERE Id=CONVERT(varchar(32),@TenantID) AND TenantID=@TenantID AND Saldo>=@Creditos AND Deleted=0;
                INSERT INTO ContratacaoUso(Id,Oferta,Quantidade,Creditos,CriadaEmUtc,TenantID,UserId,Deleted,Changed,OperationalEntityId)
                    VALUES(@Id,@Oferta,@Quantidade,@Creditos,SYSUTCDATETIME(),@TenantID,@UserId,0,SYSUTCDATETIME(),@OperationalEntityId);",
                new { Id = id, Oferta = offer.Code, Quantidade = quantity, Creditos = total, TenantID = tenantId, UserId = userId, OperationalEntityId = Guid.NewGuid().ToString("N") });
            AddMovement(tenantId, userId, "Contratacao", id, -total);
            if (offer.GrantsApplicationAccess && until.HasValue)
                work.Execute(@"IF NOT EXISTS(SELECT 1 FROM yTenantApplication WITH(UPDLOCK,HOLDLOCK) WHERE TenantID=@TenantID AND ApplicationKey=@Application AND Deleted=0)
                    INSERT INTO yTenantApplication(ApplicationKey,ValidUntil,TenantID,UserId,Deleted,Changed,OperationalEntityId)
                    VALUES(@Application,@Until,@TenantID,@UserId,0,SYSUTCDATETIME(),@OperationalEntityId);
                ELSE UPDATE yTenantApplication SET ValidUntil=CASE WHEN ValidUntil<@Until THEN @Until ELSE ValidUntil END,Changed=SYSUTCDATETIME()
                    WHERE TenantID=@TenantID AND ApplicationKey=@Application AND Deleted=0;",
                    new { Application = offer.Application, Until = until, TenantID = tenantId, UserId = userId, OperationalEntityId = Guid.NewGuid().ToString("N") });
        });
    }

    private void LockWallet(int tenantId, int userId)
    {
        if (tenantId <= 0 || userId <= 0) throw new ArgumentException("Identidade obrigatoria.");
        work.Execute(@"MERGE CarteiraCredito WITH(HOLDLOCK) AS target USING(SELECT @Id AS Id) AS source ON target.Id=source.Id
            WHEN NOT MATCHED THEN INSERT(Id,Saldo,TenantID,UserId,Deleted,Changed,OperationalEntityId)
                VALUES(@Id,0,@TenantID,@UserId,0,SYSUTCDATETIME(),@OperationalEntityId);",
            new { Id = tenantId.ToString(System.Globalization.CultureInfo.InvariantCulture), TenantID = tenantId, UserId = userId, OperationalEntityId = Guid.NewGuid().ToString("N") });
        work.ExecuteScalar<decimal>("SELECT Saldo FROM CarteiraCredito WITH(UPDLOCK,HOLDLOCK) WHERE Id=CONVERT(varchar(32),@TenantID) AND TenantID=@TenantID AND Deleted=0;", new { TenantID = tenantId });
    }

    private void AddMovement(int tenantId, int userId, string type, string reference, decimal units)
        => work.Execute(@"INSERT INTO MovimentoCredito(Id,Tipo,Referencia,Quantidade,SaldoApos,CriadoEmUtc,TenantID,UserId,Deleted,Changed,OperationalEntityId)
            SELECT @Id,@Tipo,@Referencia,@Quantidade,Saldo,SYSUTCDATETIME(),@TenantID,@UserId,0,SYSUTCDATETIME(),@OperationalEntityId
            FROM CarteiraCredito WHERE Id=CONVERT(varchar(32),@TenantID) AND TenantID=@TenantID AND Deleted=0;",
            new { Id = Hash(tenantId + ":" + type + ":" + reference), Tipo = type, Referencia = reference, Quantidade = units,
                TenantID = tenantId, UserId = userId, OperationalEntityId = Guid.NewGuid().ToString("N") });

    private void Atomic(Action action)
    {
        work.BeginTran();
        try { action(); work.Commit(); }
        catch { work.Rollback(); throw; }
    }
    private static string RequestKey(int tenantId, string requestId)
        => Guid.TryParseExact(requestId, "D", out var parsed) ? Hash(tenantId + ":" + parsed.ToString("N"))
            : throw new ArgumentException("Informe a identidade do pedido.");
    private static string Hash(string value) => Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(value)));
    private sealed class RightRow
    {
        public string ResourceKey { get; set; } = "";
        public DateTime? PeriodUntilUtc { get; set; }
        public decimal GrantedUnits { get; set; }
    }
    private sealed class DefinitionRow
    {
        public string ApplicationKey { get; set; } = "";
        public string DefinitionKey { get; set; } = "";
        public string Description { get; set; } = "";
    }
    private sealed class PurchaseRow
    {
        public string Oferta { get; set; } = "";
        public int Quantidade { get; set; }
    }
}
