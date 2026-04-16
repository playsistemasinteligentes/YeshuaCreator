using Shered.Services;
using Command.Interfaces.Patterns.Queue;
using Worker.Custon;

namespace Migrations
{
public static class WorkersBuilder
{
public static void MapWorkersBuilder(WebApplicationBuilder builder)
{

                builder.Services.AddHostedService(sp =>
                    new PollingWorker<Command.Saga.Audio_transcript_requestedOutBoxPollingWorkerHandler,
                        Command.Saga.Audio_transcript_requestedOutBoxPollingWorkerInputCommand,
                        Command.Saga.Audio_transcript_requestedOutBoxPollingWorkerOutputCommand>(
                        sp,
                        sp.GetRequiredService<
                            ILogger<PollingWorker<
                                Command.Saga.Audio_transcript_requestedOutBoxPollingWorkerHandler,
                                Command.Saga.Audio_transcript_requestedOutBoxPollingWorkerInputCommand,
                                Command.Saga.Audio_transcript_requestedOutBoxPollingWorkerOutputCommand>>>(),
                        TimeSpan.FromSeconds(5)
                    ));
                

                builder.Services.AddHostedService(sp =>
                {
                    var listener = sp.GetRequiredService<IQueueListener>();
                    var logger = sp.GetRequiredService<ILogger<QueueListenerWorker<
                        Command.Saga.Audio_transcript_requestedQueueListenerWorkerHandler,
                        Command.Saga.Audio_transcript_requestedQueueListenerWorkerInputCommand,
                        Command.Saga.Audio_transcript_requestedQueueListenerWorkerOutputCommand>>>();

                    return new QueueListenerWorker<
                        Command.Saga.Audio_transcript_requestedQueueListenerWorkerHandler,
                        Command.Saga.Audio_transcript_requestedQueueListenerWorkerInputCommand,
                        Command.Saga.Audio_transcript_requestedQueueListenerWorkerOutputCommand>(
                            sp,
                            listener,
                            logger,
                            queueName: "audio.transcript.CeleryWorker"
                    );
                });
                

                builder.Services.AddHostedService(sp =>
                    new PollingWorker<Dominio.Saga.Migration.PsychologySessionInsight.Audio_transcript_generatedInBoxPollingWorkerHandler,
                        Command.Saga.Audio_transcript_generatedInBoxPollingWorkerInputCommand,
                        Command.Saga.Audio_transcript_generatedInBoxPollingWorkerOutputCommand>(
                        sp,
                        sp.GetRequiredService<
                            ILogger<PollingWorker<
                                Dominio.Saga.Migration.PsychologySessionInsight.Audio_transcript_generatedInBoxPollingWorkerHandler,
                                Command.Saga.Audio_transcript_generatedInBoxPollingWorkerInputCommand,
                                Command.Saga.Audio_transcript_generatedInBoxPollingWorkerOutputCommand>>>(),
                        TimeSpan.FromSeconds(5)
                    ));
                

                builder.Services.AddHostedService(sp =>
                {
                    var listener = sp.GetRequiredService<IQueueListener>();
                    var logger = sp.GetRequiredService<ILogger<QueueListenerWorker<
                        Dominio.Saga.Migration.PsychologySessionInsight.Audio_transcript_generatedQueueListenerWorkerHandler,
                        Command.Saga.Audio_transcript_generatedQueueListenerWorkerInputCommand,
                        Command.Saga.Audio_transcript_generatedQueueListenerWorkerOutputCommand>>>();

                    return new QueueListenerWorker<
                        Dominio.Saga.Migration.PsychologySessionInsight.Audio_transcript_generatedQueueListenerWorkerHandler,
                        Command.Saga.Audio_transcript_generatedQueueListenerWorkerInputCommand,
                        Command.Saga.Audio_transcript_generatedQueueListenerWorkerOutputCommand>(
                            sp,
                            listener,
                            logger,
                            queueName: "audio.transcript.ConsumerWorker"
                    );
                });
                
}
}
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWorker


