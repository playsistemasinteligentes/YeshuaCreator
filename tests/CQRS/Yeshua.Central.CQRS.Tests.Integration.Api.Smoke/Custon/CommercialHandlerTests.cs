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

    private static ExecutarFinanceiroHandler Create(Context context, bool sandbox)
    {
        var finance = Fake<IFinanceiroRepository>((name, arguments) => name switch
        {
            "Read" when (int)arguments![0]! == 7 => new FinanceiroSnapshot { Balance = 27m },
            "ReadOffers" => CommercialOffers.All,
            _ => throw new InvalidOperationException("Consulta ou escrita financeira inesperada: " + name)
        });
        return new ExecutarFinanceiroHandler(finance,
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
