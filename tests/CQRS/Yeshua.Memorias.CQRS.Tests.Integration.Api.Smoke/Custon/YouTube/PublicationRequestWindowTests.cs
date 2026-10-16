using Input.Repository.PublicacaoAlbum;
using IQuery.Write;
using RepositoryInterfaces.Patterns.UnitOfWork;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

[Trait("Category", "BusinessSmoke")]
public class PublicationRequestWindowTests
{
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void GateLocksOwnedAlbumBeforeCheckingExistingRequests(int databaseResult, bool expected)
    {
        var cutoff = new DateTime(2026, 10, 15, 12, 0, 0, DateTimeKind.Utc);
        var calls = 0;
        var repository = new PublicacaoAlbumWriteRepository(TestProxy.For<IUnitOfWork>((method, args) =>
        {
            calls++;
            Assert.Equal("ExecuteScalar", method);
            var sql = Assert.IsType<string>(args[0]);
            Assert.Contains("Album WITH (UPDLOCK, HOLDLOCK)", sql);
            Assert.True(sql.IndexOf("UPDLOCK", StringComparison.Ordinal) < sql.IndexOf("NOT EXISTS", StringComparison.Ordinal));
            Assert.Contains("Id = @AlbumId AND TenantID = @TenantId AND UserId = @UserId AND Deleted = 0", sql);
            Assert.Contains("AlbumId = @LockedAlbumId AND TenantID = @TenantId AND UserId = @UserId", sql);
            Assert.Contains("SolicitadaEmUtc > @RequestedAfterUtc", sql);
            Assert.DoesNotContain("p.Status", sql);
            var parameters = args[1]!;
            object? Value(string name) => parameters.GetType().GetProperty(name)!.GetValue(parameters);
            Assert.Equal(5, Value("AlbumId")); Assert.Equal(7, Value("TenantId")); Assert.Equal(9, Value("UserId"));
            Assert.Equal(cutoff, Value("RequestedAfterUtc"));
            return databaseResult;
        }), TestProxy.For<IPublicacaoAlbumQueryWrite>());

        Assert.Equal(expected, repository.CanRequestPublication(5, 7, 9, cutoff));
        Assert.Equal(1, calls);
    }
}
