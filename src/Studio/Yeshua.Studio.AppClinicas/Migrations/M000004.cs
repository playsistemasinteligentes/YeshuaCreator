using Azure.Core;
using Dominio;
using Dominio.Migration;
using Dominio.Saga.Migration;
using Dominio.Schemas.CQRS.Abstraction;
using Microsoft.Win32;
using Migration.Dominio;
using Yeshua.Studio.AppClinicas.Domain.Entities;
using MyApp.QueryBuilder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Templates;

using static Migration.Dominio.Migration.S000002;

namespace AppClinicas
{


    [Migration(000004)]
    public class M000004 : MigrationBase
    {
        public record Menssage(string text);

        public override void Up()
        {

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
                                    // pendencia: esta saga antiga usa AddStep + AddInboxListenerWorker
                                    // para representar uma espera externa pela IA. Conceitualmente isso
                                    // deve ficar unificado como StepWait, ou o motor deve preservar a regra
                                    // de que InboxListenerWorker torna o step uma espera externa.
                                    AddStep("audioTranscriptRequested"). // “faça isso”
                                        AddOutBoxPollingWorker("ai.tasks", ExchangeType.topic, "audio.transcribe.outbox", "audio.transcribe").
                                        AddInboxListenerWorker("ai.results", ExchangeType.topic, "audio.transcribed.inbox", "audio.transcribed").


                                AddStepGroup("reportSumary").
                                    // pendencia: mesmo caso do step anterior; este step publica o pedido
                                    // de resumo e aguarda retorno externo pelo inbox antes de seguir.
                                    AddStep("reportEndProntuaryRequested"). // “faça isso”
                                        AddOutBoxPollingWorker("ai.tasks", ExchangeType.topic, "text.summarize.outbox", "text.summarize").
                                        AddInboxListenerWorker("ai.results", ExchangeType.topic, "text.summarized.inbox", "text.summarized");



            

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
