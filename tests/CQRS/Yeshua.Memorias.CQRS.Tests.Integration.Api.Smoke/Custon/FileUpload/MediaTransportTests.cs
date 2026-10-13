using Aplication.Interfaces.Services;
using Command.Interfaces.Patterns.Queue;
using Command.Patterns.OutBox;
using Command.Receivers;
using Dominio.Entitys;
using IRepository.Read;
using IRepository.Write;
using Repositorio.Outputs;
using Worker.Custon;
using static Yeshua.Memorias.Tests.PhotoUploadTests;

namespace Yeshua.Memorias.Tests;

public class MediaTransportTests
{
    [Fact]
    public async Task SendsScopedOutboxUsingTheRecordTenantAndUser()
    {
        var tenant = 0;
        var user = 0;
        var context = Context((value) => tenant = value, (value) => user = value);
        var outbox = new yOutboxDTO
        {
            id = 1, tenantid = 7, userid = 8, type = "media.album.render.requested",
            processingscope = "production", payload = "{}", messageid = "message", correlationid = "render"
        };
        var published = false;
        var completed = false;
        var receiver = new MediaOutboxTransportWorker(
            TestProxy.For<IyOutboxReadRepository>((method, args) =>
            {
                Assert.Equal("GetPendingMediaRenderMessages", method);
                Assert.Equal(5, args[0]);
                return new[] { outbox };
            }),
            TestProxy.For<IyOutboxWriteRepository>((method, args) =>
            {
                Assert.Equal(7, tenant);
                Assert.Equal(8, user);
                if (method == "UpdateStatus") completed = (int)args[1]! == 1;
                return null;
            }),
            TestProxy.For<IQueuePublisher>((method, _) =>
            {
                Assert.Equal("PublishCeleryAsync", method);
                Assert.Equal(7, tenant);
                Assert.Equal(8, user);
                published = true;
                return Task.FromResult(true);
            }), TestProxy.For<Dominio.Interfaces.ILogger>(), context);

        var result = await receiver.ExecuteAsync(new MediaOutboxTransportInputCommand());

        Assert.Equal(200, result.StatusCode);
        Assert.Equal(1, result.Data.Processed);
        Assert.True(published && completed);
    }

    [Theory]
    [InlineData("production", "RenderizarVideoAlbum", true)]
    [InlineData("development", "RenderizarVideoAlbum", false)]
    [InlineData("production", "OutroStep", false)]
    public async Task ResolvesKnownRenderSagaBeforeWritingInbox(string scope, string stepKey, bool accepted)
    {
        var tenant = 0;
        var user = 0;
        var context = Context(value => tenant = value, value => user = value);
        IyInboxEntity? stored = null;
        var logger = TestProxy.For<Dominio.Interfaces.ILogger>();
        var service = new OutboxService(TestProxy.For<IyOutboxWriteRepository>(),
            TestProxy.For<IyInboxWriteRepository>((method, args) =>
            {
                Assert.Equal("Insert", method);
                Assert.Equal(7, tenant);
                Assert.Equal(8, user);
                stored = (IyInboxEntity)args[0]!;
                return null;
            }), context, logger);
        var receiver = new MediaRenderResultInboxWorker(service,
            TestProxy.For<IySagaStepReadRepository>((_, args) =>
            {
                Assert.True((bool)args[1]!);
                return new ySagaStepDTO { id = 6, sagaid = 2, stepkey = stepKey };
            }),
            TestProxy.For<IySagaReadRepository>((_, args) =>
            {
                Assert.True((bool)args[1]!);
                return new ySagaDTO { id = 2, type = "PublicarAlbumYouTubeSaga", entityid = "3",
                    tenantid = 7, userid = 8, processingscope = scope };
            }), logger, context);

        var command = new RenderAlbumResultMessage
        {
            CorrelationId = "render", MessageId = "message", Status = "media.album.render.completed"
        };

        if (!accepted)
        {
            var rejection = await Assert.ThrowsAsync<RepositoryInterfaces.Patterns.Command.ReceiverException<MediaRenderResultOutputCommand>>(
                () => receiver.ExecuteAsync(command));
            Assert.Equal(400, rejection.State.StatusCode);
            Assert.Null(stored);
            return;
        }

        var result = await receiver.ExecuteAsync(command);

        Assert.Equal(accepted ? 200 : 400, result.StatusCode);
        if (accepted)
        {
            Assert.NotNull(stored);
            Assert.Equal(2, stored.SagaId);
            Assert.Equal(6, stored.SagaStepId);
            Assert.Equal("3", stored.EntityId);
        }
    }

    private static IExecutionContext Context(Action<int> tenant, Action<int> user) =>
        TestProxy.For<IExecutionContext>((method, args) =>
        {
            if (method == "SetTenantId") tenant((int)args[0]!);
            if (method == "SetUserId") user((int)args[0]!);
            return method == "get_ProcessingScope" ? "production" : null;
        });
}
