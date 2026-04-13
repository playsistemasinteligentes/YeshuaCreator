using Dominio;
using Dominio.Migration;
using Migration.Dominio;
using MyApp.Domain.Entities;
using MyApp.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Migration.Dominio.Migration.S000002;

namespace AppClinicas
{


    [Migration(000004)]
    public class M000004 : MigrationBase
    {
        public record Menssage(string text);

        public override void Up()
        {

            AddUsecaseGroup("Worker").AddUseCaseSubGrup("WorkerPolling").AddCommand("OutBox", new LoginInput("", ""), new LoginOutput(new List<string>(), 1, "", 1))
            .AddEntity<yOutbox>().IsWorker();

            AddUsecaseGroup("Worker").AddUseCaseSubGrup("WorkerPolling").AddCommand("Inbox", new LoginInput("", ""), new LoginOutput(new List<string>(), 1, "", 1))
            .AddEntity<yInbox>().IsWorker();


            AddUsecaseGroup("Worker").AddUseCaseSubGrup("WorkerListener").AddCommand("InBox", new Menssage(""), new Menssage(""))
            .AddEntity<yInbox>().IsListener();

            AddUsecaseGroup("Saga").AddUseCaseSubGrup("Psychology").
                            AddSaga("PsychologySessionInsight").
                            AddSagaStep("audioTranscript").
                                AddInternalEvent("audio.transcript.requested").
                                    AddOutBoxPollingWorker().
                                    AddQueueListenerWorker(
                                        new QueueTopology
                                        {
                                            Exchanges ={
                                    new ExchangeDefinition{
                                        Name = "ai.tasks",
                                        Type = ExchangeType.Topic,
                                        Bindings ={
                                            new QueueBindingDefinition{
                                                QueueName = "audio.transcript.CeleryWorker",
                                                RoutingKey = "audio.transcript.requested"
                                            }
                                        }
                                    }
                                            }
                                        }).
                                AddExternalEvent("audio.transcript.generated").
                                    AddInBoxPollingWorker().
                                    AddQueueListenerWorker(
                                        new QueueTopology
                                        {
                                            Exchanges ={
                                    new ExchangeDefinition{
                                        Name = "ai.tasks",
                                        Type = ExchangeType.Topic,
                                        Bindings ={
                                            new QueueBindingDefinition{
                                                QueueName = "audio.transcript.ConsumerWorker",
                                                RoutingKey = "audio.transcript.generated"
                                            }
                                        }
                                    }
                                            }
                                        });

            //AddInternalEvent(prontuary.sumary.requested).
            //    OutBoxWorker().
            //    Publish(Exchange: "ai.tasks", Queue: { prontuary.sumary.CeleryWorker}, Binding: prontuary.sumary.requested).

            //AddExternalEvent(audio.transcript.generated).
            //    Consumer(Exchange: "ai.tasks", Queue: { prontuary.sumary.ConsumerWorker},Binding: prontuary.sumary.generated).
            //    InboxWorker().

            //AddInternalEvent(report.sumary.requested).
            //    OutBoxWorker().
            //    Publish(Exchange: "ai.tasks", Queue: { report.sumary.CeleryWorker}, Binding: report.sumary.requested).

            //AddExternalEvent(audio.transcript.generated).
            //    Consumer(Exchange: "ai.tasks", Queue: { report.sumary.ConsumerWorker},Binding: report.sumary.generated).
            //    InboxWorker().


            /* 
            
            step inbox   
            step outbox 
            topologia de filas 
            var topology = new QueueTopology
 {
     Exchanges =
     {
         new ExchangeDefinition
         {
             Name = "ai.tasks",
             Type = "topic",
             Bindings =
             {
                 new QueueBindingDefinition
                 {
                     QueueName = "audio.transcribe.outbox",
                     RoutingKey = "audio.transcribe"
                 }
             }
         },
         new ExchangeDefinition
         {
             Name = "ai.results",
             Type = "topic",
             Bindings =
             {
                 new QueueBindingDefinition
                 {
                     QueueName = "audio.transcribed.inbox",
                     RoutingKey = "audio.transcribed"
                 }
             }
         },
         new ExchangeDefinition
         {
             Name = "ai.dead",
             Type = "topic",
             Bindings =
             {
                 new QueueBindingDefinition
                 {
                     QueueName = "audio.transcribe.dead",
                     RoutingKey = "audio.transcribe"
                 }
             }
         }
     }
 };




             */









        }
    }
}
