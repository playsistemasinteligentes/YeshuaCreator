using Dominio;
using Dominio.Migration;
using Microsoft.AspNetCore.Http;
using Migration.Dominio.Schemas.CQRS;
using MyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Templates;
using static Migration.Dominio.Migration.S000002;
using static System.Net.Mime.MediaTypeNames;

namespace Migration.Dominio.Migration
{
    [Migration(000003)]
    public class S000003 : MigrationBase
    {
        public override void Up()
        {
            // AddModule("ADM", "Administrativo");

            AddEntity("yFileUpload").AddModule("ADM")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("Type", "Tipo do Arquivo").Varchar(50).NotNull()
                .AddColumn("Status", "Status do Upload").Int().NotNull()
                    .Enumerable(0, "Pending")
                    .Enumerable(1, "Completed")
                    .Enumerable(2, "Failed")
                .AddColumn("FilePath", "Caminho do Arquivo").Varchar(500)
                .AddColumn("FileSize", "Tamanho do Arquivo").Long()
                .AddColumn("EntityType", "Entity Type").Varchar(100)
                .AddColumn("EntityId", "Entity Id").Varchar(100)
                .AddColumn("CreatedAt", "Criado em").DateTime().NotNull()
                .AddColumn("CompletedAt", "Finalizado em").DateTime()
                .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id").DefaultValue("#_currentUser.TenantID").EditFront(false).VisivelFront(false).NeedBeWhere().CanTakeOffWhere();


            AddUsecaseGroup("FileUpload").AddUseCaseSubGrup("Infra").AddCommand("StarSessionUpload",
                new AutenticationToken(""),
                new SessionUploadToken(""))
            .AddEntity<yFileUpload>(); // pendencia incluir ingeção dependencia

            AddUsecaseGroup("FileUpload").AddUseCaseSubGrup("Infra").AddCommand("SendFile",
                new SendFileCommand("", 0, false, "", "", null, "", ""),
                new SendFileResponse(true, 0, true))
            .AddEntity<yFileUpload>(); // pendencia incluir ingeção dependencia


            AddEntity("ySaga").AddModule("ADM")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull() // pendencia unic e indice 
            .AddColumn("Type", "Type").Varchar(200).NotNull()
            .AddColumn("Status", "Status").Int().NotNull() // pendencia ver necessidade de waiting 
                .Enumerable(0, "NotStarted")
                .Enumerable(1, "InProgress")
                .Enumerable(2, "Completed")
                .Enumerable(3, "Failed")
            .AddColumn("KeyCurrentStep", "Key Step Atual").Varchar(200)
            .AddColumn("CreatedAt", "Criado em").DateTime().NotNull()
            .AddColumn("CompletedAt", "Finalizado em").DateTime()
            .AddColumn("EntityType", "Entity Type").Varchar(100)
            .AddColumn("EntityId", "Entity Id").Varchar(100)
            .AddColumn("NextExecutionAt", "Proxima execucao").DateTime()
            .AddColumn("LockedAt", "LockedAt").DateTime()
            .AddColumn("LockedBy", "LockedBy").Varchar(100)
            .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id").DefaultValue("#_currentUser.TenantID").EditFront(false).VisivelFront(false).NeedBeWhere().CanTakeOffWhere();

            AddEntity("ySagaStep").AddModule("ADM")
            .AddColumn("Id", "ID").Int().Incremento().Key()
            .AddColumn("SagaId", "Saga").Int().FK("ySaga", "Id").NotNull()
            .AddColumn("StepKey", "Step Key").Varchar(200).NotNull()
            .AddColumn("IndexOrder", "Index Order").Int().NotNull()
            .AddColumn("CorrelationId", "CorrelationId").Varchar(100).NotNull()
            .AddColumn("Status", "Status").Int().NotNull()
                .Enumerable(0, "Created")
                .Enumerable(1, "Pending")
                .Enumerable(2, "InProgress")
                .Enumerable(3, "WaitingResponse")
                .Enumerable(4, "PendingApply")
                .Enumerable(5, "Completed")
                .Enumerable(6, "Failed")



        

                .AddColumn("ExecutionCount", "Execuções").Int().NotNull()
            .AddColumn("LastExecutionAt", "Última Execução").DateTime()
            .AddColumn("CompletedAt", "Finalizado em").DateTime()
            .AddColumn("ErrorMessage", "Erro").Varchar(2000)
            .AddColumn("Payload", "Payload").Varchar(8000)
            .AddColumn("RetryCount", "Tentativas").Int().NotNull()
            .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id").DefaultValue("#_currentUser.TenantID").EditFront(false).VisivelFront(false).NeedBeWhere().CanTakeOffWhere();


            AddEntity("yOutbox").AddModule("ADM")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("MessageId", "Message Id").Varchar(100)
                .AddColumn("Type", "Tipo da Mensagem").Varchar(100).NotNull()
                .AddColumn("EntityType", "Entity Type").Varchar(100)
                .AddColumn("EntityId", "Entity Id").Varchar(100)
                .AddColumn("CorrelationId", "Correlation Id").Varchar(100)
                
                .AddColumn("Payload", "Payload").Varchar(8000).NotNull()// pendencia Varchar(maxnum)
                .AddColumn("Status", "Status").Int().NotNull()
                    .Enumerable(0, "Pending")
                    .Enumerable(1, "Sent")
                    .Enumerable(2, "Failed")
                    .Enumerable(9, "Processing")

                // 🔥 TIPO DE TRANSPORTE (ENUM)
                .AddColumn("TransportType", "Tipo de Transporte").Int().NotNull()
                    .Enumerable(1, "Queue")
                    .Enumerable(2, "Http")
                    .Enumerable(3, "Socket")

                // 🔥 CONFIG FLEXÍVEL (JSON)
                .AddColumn("TransportData", "Dados do transporte").Varchar(8000)

                .AddColumn("CreatedAt", "Criado em").DateTime().NotNull()
                .AddColumn("SentAt", "Enviado em").DateTime()
                .AddColumn("RetryCount", "Tentativas").Int().NotNull()
                .AddColumn("LastError", "Último Erro").Varchar(2000)
                .AddColumn("ProcessingAt", "Processando em").DateTime() 
                .AddColumn("NextAttemptAt", "Próxima tentativa").DateTime() 


                .AddColumn("SagaId", "SagaId").FK("ySaga", "Id").Int()
                .AddColumn("SagaStepId", "SagaStepId").FK("ySagaStep", "Id").Int()
                .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id").DefaultValue("#_currentUser.TenantID").EditFront(false).VisivelFront(false).NeedBeWhere().CanTakeOffWhere();
            
            AddQuery<yOutbox>("Standard", q => q
            .WhereContext("ProximaPendente", s => s.Status == 0)
            //.Where("Geral", s => s.DataInicio >= DateTime.Today && s.DataFim <= DateTime.Today && s.StatusAgendamento == 0 && s.StatusProntuario == 0)
            .Select(s => new { s.Id, s.Type, s.Payload }));


            AddEntity("yInbox").AddModule("ADM")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("MessageId", "Message Id").Varchar(100)
                .AddColumn("Type", "Tipo da Mensagem").Varchar(100).NotNull()
                .AddColumn("EntityType", "Entity Type").Varchar(100)
                .AddColumn("EntityId", "Entity Id").Varchar(100)
                .AddColumn("CorrelationId", "Correlation Id").Varchar(100)

                .AddColumn("Payload", "Payload").Varchar(8000).NotNull()// pendencia Varchar(maxnum)
                .AddColumn("Status", "Status").Int().NotNull()
                    .Enumerable(0, "Pending")
                    .Enumerable(1, "Sent")
                    .Enumerable(2, "Failed")
                    .Enumerable(9, "Processing")


                .AddColumn("CreatedAt", "Criado em").DateTime().NotNull()
                .AddColumn("RetryCount", "Tentativas").Int().NotNull()
                .AddColumn("LastError", "Último Erro").Varchar(2000)
                .AddColumn("ProcessingAt", "Processando em").DateTime()
                .AddColumn("NextAttemptAt", "Próxima tentativa").DateTime()


                .AddColumn("SagaId", "SagaId").FK("ySaga", "Id").Int()
                .AddColumn("SagaStepId", "SagaStepId").FK("ySagaStep", "Id").Int()
                .AddColumn("TenantID", "TenantID").Int().FK("yTenant", "Id").DefaultValue("#_currentUser.TenantID").EditFront(false).VisivelFront(false).NeedBeWhere().CanTakeOffWhere();

            /*

                1. Saga.Start
                   → Step = Pending

                2. SagaWorker

                   se Pending:
                      → Execute

                      se interno:
                         → ApplyResponse (inline)
                         → Completed
                         → próximo step
                         → go to passo 2

                      se externo:
                         → Outbox
                         → WaitingResponse
                         → parar

                   se PendingApply:
                      → ApplyResponse
                      → Completed
                      → próximo step
                      → go to passo 2

                3. OutboxWorker
                   → envia mensagem

                4. QueueListener
                   → grava Inbox

                5. InboxWorker
                   → encontra saga + step (WaitingResponse)
                   → salva payload
                   → Step = PendingApply

                → go to passo 2

             */




        }
        public record SendFileCommand(string token, int ChunkIndex, bool IsFinalChunk, string FileName, string ContentType, IFormFile FileStream, string EntityId, string EntityType);
        public record SendFileResponse(bool Success, int ChunkIndex, bool IsFinalized);
        public record SessionUploadToken(string uploadToken);
        public record AutenticationToken(string token);

    }
}
