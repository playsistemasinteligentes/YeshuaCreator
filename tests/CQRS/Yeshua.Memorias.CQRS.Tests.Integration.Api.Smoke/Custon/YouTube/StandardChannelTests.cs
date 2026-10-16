using Aplication.Interfaces.Services;
using Command.Receivers.UseCase;
using Command.UseCase;
using Dominio.Interfaces;
using Input.Repository.CanalStandard;
using IRepository.Read;
using IRepository.Write;
using Memorias.YouTube;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.UnitOfWork;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class StandardChannelTests
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task InternalCommandReturnsReservationOrNoAvailability(bool available)
    {
        var calls = 0;
        var channel = new CanalStandardDTO { id = 12, canalid = "channel", conexaoyoutubeid = new string('a', 32), credencialtenantid = 90 };
        var handler = Create(7, 8, () => { calls++; return available ? channel : null; });
        var result = await handler.ExecuteAsync(new ReservarCanalStandardInputCommand());
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(1, calls);
        Assert.Equal(available, result.Data.Disponivel);
        Assert.Equal(available ? 12 : 0, result.Data.CanalStandardId);
        Assert.Equal(available ? 90 : 0, result.Data.CredencialTenantId);
    }

    [Fact]
    public async Task AvailabilityDoesNotReserveOrReturnCredentialMetadata()
    {
        var handler = Create(7, 8, () => throw new Exception("Availability must not reserve."));
        var result = await handler.ExecuteAsync(new ReservarCanalStandardInputCommand { SomenteConsultar = true });
        Assert.True(result.Data.Disponivel);
        Assert.Equal(0, result.Data.CredencialTenantId);
        Assert.Empty(result.Data.ConexaoYouTubeId);
        Assert.Empty(result.Data.CanalId);
    }

    [Fact]
    public async Task DisconnectedAccountIsNotEligible()
    {
        var handler = Create(7, 8, () => throw new Exception("Disconnected channel must not reserve."), connected: false);
        var result = await handler.ExecuteAsync(new ReservarCanalStandardInputCommand());
        Assert.False(result.Data.Disponivel);
    }

    [Theory]
    [InlineData(0, 8)]
    [InlineData(7, 0)]
    public async Task RejectsMissingContextBeforeAccessingGlobalRepository(int tenant, int user)
    {
        var calls = 0;
        var handler = Create(tenant, user, () => { calls++; return null; });
        var result = await handler.ExecuteAsync(new ReservarCanalStandardInputCommand());
        Assert.Equal(400, result.StatusCode);
        Assert.Equal(0, calls);
    }

    [Fact]
    public void RepositorySelectsAndReservesAtomicallyWithoutFilteringByCallerTenant()
    {
        var calls = 0;
        var expected = new CanalStandardDTO { id = 12 };
        var repository = new CanalStandardWriteRepository(TestProxy.For<IUnitOfWork>((method, args) =>
        {
            calls++;
            Assert.Equal("QueryFirstOrDefault", method);
            var sql = Assert.IsType<string>(args[0]);
            Assert.Contains("WITH (UPDLOCK, HOLDLOCK)", sql);
            Assert.Contains("ORDER BY TotalReservas, UltimaReservaEmUtc, Id", sql);
            Assert.Contains("UPDATE candidato", sql);
            Assert.Contains("Id IN @CanaisElegiveis", sql);
            Assert.Contains("OUTPUT inserted.Id", sql);
            Assert.Contains("Ativo = 1", sql);
            Assert.Contains("ISNULL(Deleted, 0) = 0", sql);
            Assert.DoesNotContain("@Tenant", sql);
            Assert.DoesNotContain("@User", sql);
            return expected;
        }));
        Assert.Same(expected, repository.ReservarDisponivel([12]));
        Assert.Equal(1, calls);
    }

    private static ReservarCanalStandardHandler Create(int tenant, int user, Func<CanalStandardDTO?> reserve, bool connected = true)
    {
        return new ReservarCanalStandardHandler(TestProxy.For<IUnitOfWork>(), TestProxy.For<Dominio.Interfaces.ILogger>(),
            TestProxy.For<IExecutionContext>((method, _) => method switch { "get_TenantID" => tenant, "get_UserId" => user, _ => null }),
            TestProxy.For<IDomainTrackingPolicy>(), TestProxy.For<ICanalStandardReadRepository>((_, _) => new List<CanalStandardDTO>
            {
                new() { id = 12, canalid = "channel", conexaoyoutubeid = new string('a', 32), credencialtenantid = 90 },
                new() { id = 13, canalid = "channel", conexaoyoutubeid = new string('a', 32), credencialtenantid = 90 }
            }),
            TestProxy.For<ICanalStandardWriteRepository>((method, args) =>
            {
                Assert.Equal("ReservarDisponivel", method);
                Assert.Equal(new[] { 12 }, (int[])args[0]!);
                return reserve();
            }), TestProxy.For<IYouTubeConnectionService>((method, args) =>
            {
                Assert.Equal("ListAsync", method);
                Assert.Equal(90, ((YouTubeOwner)args[0]!).TenantId);
                return Task.FromResult(new YouTubeConnections(true, [new(true, connected, "channel", ConexaoId: new string('a', 32))]));
            }));
    }
}
