using System.Globalization;
using System.Security.Claims;
using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Commercial;
using Dominio.Commercial.Central;
using Dominio.Interfaces;
using IRepository.Read;
using RepositoryInterfaces.Commercial;
using RepositoryInterfaces.Commercial.Central;
using RepositoryInterfaces.Patterns.Command;

namespace Command.Receivers.UseCase;

public partial class ExecutarFinanceiroHandler
{
    private readonly IFinanceiroRepository _financeiro;
    private readonly IyTenantReadRepository _tenants;
    private readonly IyUserReadRepository _users;
    private readonly IyTenantApplicationReadRepository _applications;
    private readonly ICommercialTokenIssuer _tokens;
    private readonly BillingPrototypeOptions _options;

    public ExecutarFinanceiroHandler(IFinanceiroRepository financeiro, IyTenantReadRepository tenants,
        IyUserReadRepository users, IyTenantApplicationReadRepository applications, ICommercialTokenIssuer tokens,
        BillingPrototypeOptions options, ILogger logger, IExecutionContext context) : this(logger, context)
    { _financeiro = financeiro; _tenants = tenants; _users = users; _applications = applications; _tokens = tokens; _options = options; }

    protected partial Task<State<ExecutarFinanceiroOutputCommand>> CustomActionHookAsync(
        State<ExecutarFinanceiroOutputCommand> state, ExecutarFinanceiroInputCommand command, CancellationToken cancellationToken)
    {
        try
        {
            var tenantId = _executionContext.TenantID;
            var userId = _executionContext.UserId;
            var tenant = _tenants.FirstById(tenantId) ?? throw new ArgumentException("Tenant nao encontrado.");
            var user = _users.FirstById(userId) ?? throw new ArgumentException("Usuario nao encontrado.");
            if (user.tenantid != tenantId) throw new ArgumentException("Usuario nao pertence ao tenant.");
            if (command.Operacao is not ("consultar" or "atualizar") && tenant.userid != userId)
                throw new ArgumentException("Somente o responsavel pelo tenant pode contratar ou confirmar pagamentos.");
            var chargeId = "";
            switch (command.Operacao)
            {
                case "consultar": case "atualizar": break;
                case "adicionar":
                    if (!_options.SandboxEnabled) throw new ArgumentException("Adição demonstrativa indisponível neste ambiente.");
                    _financeiro.AddWalletCredits(tenantId, userId, command.RequestId, command.Creditos);
                    break;
                case "recarga":
                    if (!_options.SandboxEnabled) throw new ArgumentException("Recarga demonstrativa indisponivel neste ambiente.");
                    chargeId = _financeiro.CreateCharge(tenantId, userId, command.RequestId, command.Creditos);
                    break;
                case "confirmar":
                    if (!_options.SandboxEnabled) throw new ArgumentException("Confirmacao simulada indisponivel neste ambiente.");
                    _financeiro.ConfirmSandboxPayment(tenantId, userId, command.CobrancaId);
                    break;
                case "alocar":
                    _financeiro.AllocateWalletCredits(tenantId, userId, command.RequestId, command.Oferta, command.Quantidade);
                    break;
                default: throw new ArgumentException("Operacao financeira invalida.");
            }
            var snapshot = _financeiro.Read(tenantId);
            var output = new ExecutarFinanceiroOutputCommand
            {
                Saldo = snapshot.Balance, Simulacao = _options.SandboxEnabled, CobrancaId = chargeId,
                Direitos = UsageRightClaims.Write(snapshot.Rights),
                Ofertas = _financeiro.ReadOffers().Select(offer => new OfertaFinanceiraInfo
                    { Codigo = offer.Code, Titulo = offer.Title, Aplicativo = offer.Application, Recurso = offer.Resource,
                        Modelo = offer.Model, PrecoCreditos = offer.PriceCredits, Meses = offer.Months, Unidades = offer.Units }).ToList(),
                Contratacoes = snapshot.Rights.Select(right => new DireitoFinanceiroInfo { Recurso = right.Resource,
                    ValidoAteUtc = right.Until > 0 ? DateTimeOffset.FromUnixTimeSeconds(right.Until).ToString("O") : "", UnidadesContratadas = right.GrantedUnits }).ToList(),
                Movimentos = snapshot.Movements.Select(movement => new MovimentoFinanceiroInfo { Tipo = movement.Tipo, Referencia = movement.Referencia,
                    Quantidade = movement.Quantidade, SaldoApos = movement.SaldoApos, SaldoAnterior = movement.SaldoApos - movement.Quantidade,
                    Servico = movement.Servico, Descricao = movement.Descricao,
                    CriadoEmUtc = DateTime.SpecifyKind(movement.CriadoEmUtc, DateTimeKind.Utc).ToString("O") }).ToList(),
                Cobrancas = snapshot.Charges.Select(charge => new CobrancaFinanceiraInfo
                    { Id = charge.Id, Creditos = charge.Creditos, Valor = charge.Valor, Status = charge.Status }).ToList()
            };
            if (command.Operacao is "alocar" or "atualizar")
            {
                var catalogs = new[] { "Central" }.Concat(_applications.GetAllByTenantID(tenantId)
                    .Where(application => application.validuntil > DateTime.UtcNow).Select(application => application.applicationkey))
                    .Distinct(StringComparer.OrdinalIgnoreCase);
                output.Token = _tokens.Issue(new List<Claim>
                {
                    new(ClaimTypes.NameIdentifier, userId.ToString(CultureInfo.InvariantCulture)),
                    new(ClaimTypes.Email, user.email), new(ClaimTypes.Role, "Admin"),
                    new("tenantId", tenantId.ToString(CultureInfo.InvariantCulture)),
                    new("userModules", ""), new("userCatalogs", string.Join(",", catalogs)),
                    new("tokenOrigin", "Central"), new("application", "Central"),
                    new("tenantDocument", tenant.cnpjcpf), new("tenantName", tenant.nome), new("userName", user.nome)
                }, snapshot.Rights);
            }
            return Task.FromResult(Success("Consulta financeira concluida.", output));
        }
        catch (Exception exception) when (exception is ArgumentException or InvalidOperationException)
        { return Task.FromResult(ValidationError(exception.Message, new ExecutarFinanceiroOutputCommand())); }
    }
}
