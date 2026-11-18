using System.Reflection;
using System.Security.Claims;
using Aplication.Interfaces.Services;
using Command.Receivers.UseCase;
using Command.UseCase;
using Dominio.Commercial.Central;
using IRepository.Read;
using Repositorio.Outputs;
using RepositoryInterfaces.Commercial;
using RepositoryInterfaces.Commercial.Central;

namespace Central.Tests.Commercial;

public sealed class CommercialHandlerTests
{
    [Fact]
    public async Task Financial_read_uses_the_authenticated_tenant_through_the_public_receiver()
    {
        var context = new Context(12);
        var core = Create(context, true);
        var response = await new ConsultarFinanceiroHandler(core, new Shered.Logger.Logger(), context)
            .ExecuteAsync(new ConsultarFinanceiroInputCommand());
        Assert.Equal(200, response.StatusCode);
        Assert.Equal(27m, response.Data.Saldo);
        Assert.Equal(3, response.Data.Ofertas.Count);
    }

    [Fact]
    public async Task Tenant_member_cannot_purchase_even_with_an_authenticated_session()
    {
        var context = new Context(13);
        var response = await new ContratarUsoHandler(Create(context, true), new Shered.Logger.Logger(), context)
            .ExecuteAsync(new ContratarUsoInputCommand { Oferta = "clinica-periodo", Quantidade = 1, RequestId = Guid.NewGuid().ToString("D") });
        Assert.Equal(400, response.StatusCode);
        Assert.Contains("responsavel", response.Message);
    }

    [Fact]
    public async Task Sandbox_disabled_prevents_simulated_confirmation_before_repository_write()
    {
        var context = new Context(12);
        var response = await new ConfirmarPagamentoTesteHandler(Create(context, false), new Shered.Logger.Logger(), context)
            .ExecuteAsync(new ConfirmarPagamentoTesteInputCommand { CobrancaId = new string('A', 64) });
        Assert.Equal(400, response.StatusCode);
        Assert.Contains("indisponivel", response.Message);
    }

    [Fact]
    public async Task Wallet_addition_calls_the_named_operation_with_authenticated_identity_and_no_charge()
    {
        var requestId = Guid.NewGuid().ToString("D");
        var writes = 0;
        var finance = Fake<IFinanceiroRepository>((name, args) => name switch
        {
            "AddWalletCredits" => Added(args),
            "Read" => new FinanceiroSnapshot { Balance = 50m },
            "ReadOffers" => CommercialOffers.All,
            _ => throw new InvalidOperationException("Unexpected operation: " + name)
        });
        object? Added(object?[]? args)
        {
            Assert.Equal(7, args![0]); Assert.Equal(12, args[1]); Assert.Equal(requestId, args[2]); Assert.Equal(50m, args[3]);
            writes++; return null;
        }
        var response = await new AdicionarCreditosCarteiraHandler(Create(new Context(12), true, finance), new Shered.Logger.Logger(), new Context(12))
            .ExecuteAsync(new AdicionarCreditosCarteiraInputCommand { Creditos = 50, RequestId = requestId });
        Assert.Equal(200, response.StatusCode); Assert.Equal(50m, response.Data.Saldo); Assert.Equal(1, writes);
        Assert.Empty(response.Data.CobrancaId);
    }

    [Fact]
    public async Task Wallet_addition_remains_explicitly_enabled_and_owner_only()
    {
        foreach (var context in new[] { new Context(12), new Context(13) })
        {
            var response = await new AdicionarCreditosCarteiraHandler(Create(context, context.UserId == 13), new Shered.Logger.Logger(), context)
                .ExecuteAsync(new AdicionarCreditosCarteiraInputCommand { Creditos = 50, RequestId = Guid.NewGuid().ToString("D") });
            Assert.Equal(400, response.StatusCode);
        }
        var member = new Context(13);
        var allocation = await new AlocarCreditosCarteiraHandler(Create(member, true), new Shered.Logger.Logger(), member)
            .ExecuteAsync(new AlocarCreditosCarteiraInputCommand { Oferta = "clinica-periodo", Quantidade = 1, RequestId = Guid.NewGuid().ToString("D") });
        Assert.Equal(400, allocation.StatusCode);
    }

    [Fact]
    public async Task Wallet_statement_preserves_service_and_derives_the_previous_balance_from_each_movement()
    {
        var context = new Context(12);
        var finance = Fake<IFinanceiroRepository>((name, _) => name switch
        {
            "Read" => new FinanceiroSnapshot { Balance = 50m, Movements = [new FinanceiroMovement {
                Tipo = "AlocacaoCarteira", Quantidade = -100, SaldoApos = 50,
                Servico = "clinica.access", Descricao = "Clínica — 1 mês(es)" }] },
            "ReadOffers" => CommercialOffers.All,
            _ => throw new InvalidOperationException(name)
        });
        var response = await new ConsultarFinanceiroHandler(Create(context, true, finance), new Shered.Logger.Logger(), context)
            .ExecuteAsync(new ConsultarFinanceiroInputCommand());
        var movement = Assert.Single(response.Data.Movimentos);
        Assert.Equal(150m, movement.SaldoAnterior); Assert.Equal(50m, movement.SaldoApos);
        Assert.Equal("clinica.access", movement.Servico); Assert.Equal("Clínica — 1 mês(es)", movement.Descricao);
    }

    private static ExecutarFinanceiroHandler Create(Context context, bool sandbox, IFinanceiroRepository? repository = null)
    {
        var finance = Fake<IFinanceiroRepository>((name, arguments) => name switch
        {
            "Read" when (int)arguments![0]! == 7 => new FinanceiroSnapshot { Balance = 27m },
            "ReadOffers" => CommercialOffers.All,
            _ => throw new InvalidOperationException("Consulta ou escrita financeira inesperada: " + name)
        });
        return new ExecutarFinanceiroHandler(repository ?? finance,
            Fake<IyTenantReadRepository>((_, _) => new yTenantDTO { id = 7, userid = 12 }),
            Fake<IyUserReadRepository>((_, _) => new yUserDTO { id = context.UserId, tenantid = 7 }),
            Fake<IyTenantApplicationReadRepository>((_, _) => throw new InvalidOperationException("Catalogo inesperado.")),
            Fake<ICommercialTokenIssuer>((_, _) => throw new InvalidOperationException("Token inesperado.")),
            new BillingPrototypeOptions { SandboxEnabled = sandbox }, new Shered.Logger.Logger(), context);
    }

    public class Stub<T> : DispatchProxy
    {
        public Func<string, object?[]?, object?> Call = null!;
        protected override object? Invoke(MethodInfo? method, object?[]? args) => Call(method!.Name, args);
    }
    private static T Fake<T>(Func<string, object?[]?, object?> call) where T : class
    {
        var proxy = DispatchProxy.Create<T, Stub<T>>();
        ((Stub<T>)(object)proxy).Call = call;
        return proxy;
    }
    private sealed class Context(int user) : IExecutionContext
    {
        public int TenantID { get; private set; } = 7;
        public int UserId { get; private set; } = user;
        public IEnumerable<Claim> Claims => [];
        public string TraceId { get; private set; } = "commercial-handler-test";
        public ExecutionOrigin Origem { get; private set; } = ExecutionOrigin.Http;
        public string ProcessingScope => "commercial-handler-test";
        public void SetTenantId(int id) => TenantID = id;
        public void SetUserId(int id) => UserId = id;
        public void SetTraceId(string value) => TraceId = value;
        public void SetOrigem(ExecutionOrigin value) => Origem = value;
    }
}
