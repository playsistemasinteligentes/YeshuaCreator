using Aplication.Interfaces.Services;
using Command.Read;
using Query.Read;
using Read.Repository;
using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.UnitOfWork;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class AlbumSharingOwnershipTests
{
    [Theory]
    [InlineData(null)]
    [InlineData(9)]
    [InlineData(99)]
    public void AlbumReadAlwaysFiltersAuthenticatedOwner(int? requestedUser)
    {
        var context = Context();
        var calls = 0;
        var repository = new AlbumReadRepository(TestProxy.For<IUnitOfWork>((method, args) =>
        {
            Assert.Equal("Query", method); calls++;
            AssertScope(args); return Array.Empty<AlbumDTO>();
        }), context, new AlbumQueryRead(context));
        var result = repository.getAlbum(new AlbumReadCommand { UserId = requestedUser, TenantID = 88 });
        Assert.Empty(result.Items); Assert.Equal(1, calls);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(9)]
    [InlineData(99)]
    public void PublishedVideoReadAlwaysFiltersAuthenticatedOwnerAndAlbum(int? requestedUser)
    {
        var context = Context();
        var calls = 0;
        var repository = new PublicacaoAlbumReadRepository(TestProxy.For<IUnitOfWork>((method, args) =>
        {
            Assert.Equal("Query", method); calls++;
            AssertScope(args);
            Assert.Equal(11, ((IDictionary<string, object>)args[1]!)["AlbumId"]);
            return Array.Empty<PublicacaoAlbumDTO>();
        }), context, new PublicacaoAlbumQueryRead(context));
        var result = repository.getPublicacaoAlbum(new PublicacaoAlbumReadCommand { AlbumId = 11, UserId = requestedUser, TenantID = 88 });
        Assert.Empty(result.Items); Assert.Equal(1, calls);
    }

    private static IExecutionContext Context() => TestProxy.For<IExecutionContext>((name, _) => name switch
    {
        "get_UserId" => 9, "get_TenantID" => 7, _ => null
    });
    private static void AssertScope(object?[] args)
    {
        var sql = (string)args[0]!;
        var parameters = (IDictionary<string, object>)args[1]!;
        Assert.Contains("[UserId] = @UserId", sql); Assert.Equal(9, parameters["UserId"]);
        Assert.Contains("[TenantID] = @TenantID", sql); Assert.Equal(7, parameters["TenantID"]);
        Assert.Equal(0, parameters["Deleted"]);
    }
}
