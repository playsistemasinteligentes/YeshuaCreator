using Dominio;
using Dominio.Migration;
using Dominio.Schemas.CQRS;
namespace TestMigration;

[TestClass]
public sealed class SagaQueueGenerationTests
{
    [TestMethod]
    public void Generated_queue_workers_are_explicit_and_use_only_declared_queues()
    {
        var migration = new QueueMigration();
        migration.Up();
        var directory = Path.Combine(Path.GetTempPath(), "yeshua-saga-queues-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var workers = Path.Combine(directory, "Workers.cs");
            new SourceCodeInfraestructureWorker(migration).WriteCode(null, workers, Path.Combine(directory, "Workers.Custon.cs"));
            var result = File.ReadAllText(workers);
            StringAssert.Contains(result, "yOutBoxWorkerHandler");
            StringAssert.Contains(result, "InboxListenerHandler");
            StringAssert.Contains(result, "audio.transcribed.inbox");
            Assert.IsFalse(result.Contains("text.summarized.inbox"));
            var listener = Path.Combine(directory, "InboxListener.cs");
            new SourceCodeApplicationSagaQueueWorkers(migration, true).WriteGeneratedCode(listener);
            var code = File.ReadAllText(listener);
            StringAssert.Contains(code, "AudioSaga");
            StringAssert.Contains(code, "Transcribe");
            StringAssert.Contains(code, "CanReceiveResult");
            StringAssert.Contains(code, "ProcessingScope");
            StringAssert.Contains(code, "IsDeclaredContract");
            StringAssert.Contains(code, "\"audio.transcribed\"");
            StringAssert.Contains(code, "AcceptWithinTransaction");
            var outbox = Path.Combine(directory, "Outbox.cs");
            new SourceCodeApplicationSagaQueueWorkers(migration, false).WriteGeneratedCode(outbox);
            var delivery = File.ReadAllText(outbox);
            StringAssert.Contains(delivery, "IOutboxDeliveryFactory");
            StringAssert.Contains(delivery, "\"audio.transcribe\" => \"audio.transcribed\"");
            StringAssert.Contains(delivery, "_inbox.AcceptWithinTransaction");
            StringAssert.Contains(delivery, "MarkDeliveryDone");
            Assert.IsFalse(delivery.Contains("OpenAI"), "Provider-specific code belongs to the application.");
        }
        finally { Directory.Delete(directory, true); }
    }

    [TestMethod]
    public void Sagas_without_queue_policy_do_not_generate_queue_transport_workers()
    {
        var migration = new InternalMigration();
        migration.Up();
        var directory = Path.Combine(Path.GetTempPath(), "yeshua-saga-internal-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var path = Path.Combine(directory, "Workers.cs");
            new SourceCodeInfraestructureWorker(migration).WriteCode(null, path, Path.Combine(directory, "Custon.cs"));
            var result = File.ReadAllText(path);
            StringAssert.Contains(result, "SagaWorkerCommandHandler");
            Assert.IsFalse(result.Contains("yOutBoxWorkerHandler"));
            Assert.IsFalse(result.Contains("InboxListenerHandler"));
        }
        finally { Directory.Delete(directory, true); }
    }

    private sealed class QueueMigration : MigrationBase
    {
        public override void Up()
        {
            ConfigureSagaWorkers(2000, generateQueueWorkers: true);
            AddUsecaseGroup("Tests").AddUseCaseSubGrup("Audio").AddSaga("Audio")
                .AddStepGroup("transcription").AddStepWait("transcribe")
                .AddOutBoxPollingWorker("ai.tasks", ExchangeType.topic, "audio.transcribe.outbox", "audio.transcribe")
                .AddInboxListenerWorker("ai.results", ExchangeType.topic, "audio.transcribed.inbox", "audio.transcribed");
        }
    }
    private sealed class InternalMigration : MigrationBase
    {
        public override void Up()
            => AddUsecaseGroup("Tests").AddUseCaseSubGrup("Internal").AddSaga("Internal")
                .AddStepGroup("execution").AddStep("process");
    }
}
