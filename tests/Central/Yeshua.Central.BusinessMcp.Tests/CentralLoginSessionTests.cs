using Aplication.Interfaces.Services;
using Central.AgentOAuth;
using Command.Authentication;
using Command.Receivers.UseCase;
using Command.UseCase;
using Dominio.Commercial;
using Dominio.Interfaces;
using IRepository.Read;
using IRepository.Write;
using Moq;
using Repositorio.Outputs;
using RepositoryInterfaces.Commercial.Central;
using RepositoryInterfaces.Patterns.UnitOfWork;

namespace Yeshua.Central.BusinessMcp.Tests;

public sealed class CentralLoginSessionTests
{
    [Fact]
    public async Task ConventionalLoginAndOAuthUseTheSameRepositoriesAndCatalogueResolution()
    {
        var f = new Fixture();
        var conventional = await f.Login.ExecuteAsync(new LoginInputCommand { email = "owner@example.test", password = "synthetic-password" });
        var delegated = await f.OAuth.LoginAsync("owner@example.test", "synthetic-password", default);
        var refreshed = await f.OAuth.ResolveAsync(17, 7, default);
        Assert.Equal(200, conventional.StatusCode);
        Assert.NotNull(delegated); Assert.NotNull(refreshed);
        Assert.Equal(["Central", "Clinica"], conventional.Data.catalogos);
        Assert.Equal(conventional.Data.catalogos, delegated.catalogos);
        Assert.Equal(delegated.catalogos, refreshed.catalogos);
        Assert.Empty(refreshed.modulos); // Do not invent grants from existing profile tables.
        Assert.Equal(17, refreshed.UserId); Assert.Equal(7, refreshed.tenantId);
        f.Writes.VerifyNoOtherCalls();
        f.Finance.Verify(r => r.ReadRights(7), Times.Exactly(3));
    }
    [Fact]
    public async Task InvalidConventionalCredentialsAndCrossTenantRenewalAreDenied()
    {
        var f = new Fixture();
        Assert.Null(await f.OAuth.LoginAsync("owner@example.test", "wrong", default));
        Assert.Null(await f.OAuth.ResolveAsync(17, 8, default));
        f.Apps.Verify(r => r.GetAllByTenantID(It.IsAny<int>()), Times.Never());
        f.Writes.VerifyNoOtherCalls();
    }
    [Fact]
    public async Task DeletedOwnerAndExpiredApplicationsNeverReappearAtRenewal()
    {
        var f = new Fixture();
        f.User.deleted = true;
        Assert.Null(await f.OAuth.ResolveAsync(17, 7, default));
        f.Apps.Verify(r => r.GetAllByTenantID(It.IsAny<int>()), Times.Never());
    }
    private sealed class Fixture
    {
        internal yUserDTO User = new() { id = 17, tenantid = 7, email = "owner@example.test", senha = "synthetic-password", nome = "Synthetic" };
        internal Mock<IyUserWriteRepository> Writes = new();
        internal Mock<IyTenantApplicationReadRepository> Apps = new();
        internal Mock<IFinanceiroRepository> Finance = new();
        internal LoginHandler Login;
        internal CentralAgentIdentity OAuth;
        internal Fixture()
        {
            var users = new Mock<IyUserReadRepository>();
            users.Setup(r => r.FirstByEmail("owner@example.test", true)).Returns(User);
            users.Setup(r => r.FirstById(17, true)).Returns(User);
            var tenants = new Mock<IyTenantReadRepository>();
            tenants.Setup(r => r.FirstById(7, true)).Returns(new yTenantDTO { id = 7, nome = "Synthetic tenant", cnpjcpf = "synthetic-document" });
            Apps.Setup(r => r.GetAllByTenantID(7)).Returns([
                new() { applicationkey = "Clinica", tenantid = 7, validuntil = DateTime.UtcNow.AddDays(1) },
                new() { applicationkey = "Expired", tenantid = 7, validuntil = DateTime.UtcNow.AddDays(-1) },
                new() { applicationkey = "Deleted", tenantid = 7, deleted = true, validuntil = DateTime.UtcNow.AddDays(1) }]);
            Finance.Setup(r => r.ReadRights(7)).Returns(Array.Empty<UsageRight>());
            var context = new Mock<IExecutionContext>();
            Login = new(new Mock<IUnitOfWork>().Object, new Mock<Dominio.Interfaces.ILogger>().Object,
                context.Object, new Mock<IDomainTrackingPolicy>().Object, users.Object, Writes.Object, Apps.Object, tenants.Object, Finance.Object);
            OAuth = new(Login, new CentralLoginSessionReader(users.Object, tenants.Object, Apps.Object, Finance.Object, context.Object));
        }
    }
}
