using Dominio;
using Dominio.Migration;
using Dominio.Schemas.CQRS.Abstraction;
using Migration.Dominio;
using MyApp.Domain.Entities;
using MyApp.QueryBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
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

            /*

1.Produces → evento de intenção(comando disfarçado)
audio.transcript.requested
👉 Significa: “alguém precisa fazer isso”


2.Consumes → evento de resultado(fato)
audio.transcript.generated

👉 Significa:“isso já aconteceu”




Tipo Natureza    Quem dispara    Pra quê
Produces intenção    Saga mandar executar
Consumes    fato sistema externo continuar fluxo

🎯 Regra de ouro(essa aqui é crucial)
❗ O step NÃO É o evento
❗ Ele só representa o ponto do fluxo onde aquele evento acontece

            */

                AddUsecaseGroup("Saga").AddUseCaseSubGrup("Psychology").
                                AddSaga("PsychologySessionInsight").
                                AddStepGroup("audioTranscript").
                                    AddStep("audio_transcript_requested"). // “faça isso”
                                        AddOutBoxPollingWorker("ai.tasks", ExchangeType.Topic, "audio.transcript.CeleryWorker", "audio.transcript.requested").
                                    //.LazyWorker vai ser executado apenas no loopingWorker 
                                    //.AsyncFirt   vai executar a primeira vez caso falhe sera executada pelo loopingWorker  
                                    //.StandardOutBox   um outbox por saga ou por sistema ou por step

                                    AddStep("audio_transcript_generated"). //“isso aconteceu”
                                        AddQueueListenerWorker("ai.tasks", ExchangeType.Topic, "audio.transcript.ConsumerWorker", "audio.transcript.generated").
                                        AddInBoxPollingWorker().

                                AddStepGroup("prontuarySumary").
                                    AddStep("prontuary_sumary_requested"). // “faça isso”
                                        AddOutBoxPollingWorker("ai.tasks", ExchangeType.Topic, "prontuary.sumary.CeleryWorker", "prontuary.sumary.requested").
                                    AddStep("prontuary_sumary_generated"). //“isso aconteceu”
                                        AddQueueListenerWorker("ai.tasks", ExchangeType.Topic, "prontuary.sumary.ConsumerWorker", "prontuary.sumary.generated").
                                        AddInBoxPollingWorker();


            

            //AddStep(prontuary.sumary.requested).
            //    OutBoxWorker().
            //    Publish(Exchange: "ai.tasks", Queue: { prontuary.sumary.CeleryWorker}, Binding: prontuary.sumary.requested).

            //AddExternalEvent(audio.transcript.generated).
            //    Consumer(Exchange: "ai.tasks", Queue: { prontuary.sumary.ConsumerWorker},Binding: prontuary.sumary.generated).
            //    InboxWorker().

            //AddStep(report.sumary.requested).
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
