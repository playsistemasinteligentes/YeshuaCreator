using Dominio;
using Dominio.Migration;
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



            AddEntity("yFileUpload").AddModule("INFRA")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("IdempotencyKey", "Idempotency Key").Varchar(100).NotNull()// pendencia unic 
                .AddColumn("Type", "Tipo do Arquivo").Varchar(50).NotNull()
                .AddColumn("Status", "Status do Upload").Int().NotNull()
                    .Enumerable(0, "Pending")
                    .Enumerable(1, "Completed")
                    .Enumerable(2, "Failed")
                .AddColumn("FilePath", "Caminho do Arquivo").Varchar(500)
                .AddColumn("FileSize", "Tamanho do Arquivo").Int()
                .AddColumn("ContentType", "Content Type").Varchar(100)
                .AddColumn("CreatedAt", "Criado em").DateTime().NotNull()
                .AddColumn("CompletedAt", "Finalizado em").DateTime();

            AddUsecaseGroup("FileUpload").AddUseCaseSubGrup("Infra").AddUseCaseCommand("SendFile",
                new SendFileCommand("", 0, false, "", "", null),
                new SendFileResponse(true, 0, true))
            .AddEntity<yFileUpload>().IsWorker();


            AddEntity("yOutbox").AddModule("INFRA")
                .AddColumn("Id", "ID").Int().Incremento().Key()
                .AddColumn("MessageId", "Message Id").Varchar(100).DefaultValue("#Guid.NewGuid()").NotNull()
                .AddColumn("JobId", "Job Id").Varchar(100).DefaultValue("#Guid.NewGuid()").NotNull()
                .AddColumn("CorrelationId", "Correlation Id").Varchar(100).NotNull()
                .AddColumn("Type", "Tipo da Mensagem").Varchar(100).NotNull()
                .AddColumn("Payload", "Payload").Varchar(8000).NotNull()// pendencia Varchar(maxnum)
                .AddColumn("Status", "Status").Int().NotNull()
                    .Enumerable(0, "Pending")
                    .Enumerable(1, "Sent")
                    .Enumerable(2, "Failed")
                .AddColumn("CreatedAt", "Criado em").DateTime().NotNull()
                .AddColumn("SentAt", "Enviado em").DateTime()
                .AddColumn("RetryCount", "Tentativas").Int().NotNull()
                .AddColumn("LastError", "Último Erro").Varchar(2000);

            AddQuery<yOutbox>("Standard", q => q
            .WhereContext("ProximaPendente", s => s.Status == 0)
            //.Where("Geral", s => s.DataInicio >= DateTime.Today && s.DataFim <= DateTime.Today && s.StatusAgendamento == 0 && s.StatusProntuario == 0)
            .Select(s => new { s.Id }));


            AddEntity("yInbox").AddModule("INFRA")
               .AddColumn("Id", "ID").Int().Incremento().Key()
               .AddColumn("MessageId", "Message Id").Varchar(100).DefaultValue("#Guid.NewGuid()").NotNull()
               .AddColumn("JobId", "Job Id").Varchar(100).DefaultValue("#Guid.NewGuid()").NotNull()
               .AddColumn("CorrelationId", "Correlation Id").Varchar(100).NotNull()
                .AddColumn("Type", "Tipo da Mensagem").Varchar(100).NotNull()
                .AddColumn("Payload", "Payload").Varchar(8000).NotNull()// pendencia Varchar(maxnum)
                .AddColumn("Status", "Status").Int().NotNull()
                    .Enumerable(0, "Pending")
                    .Enumerable(1, "Sent")
                    .Enumerable(2, "Failed")
                .AddColumn("CreatedAt", "Criado em").DateTime().NotNull()
                .AddColumn("SentAt", "Enviado em").DateTime()
                .AddColumn("RetryCount", "Tentativas").Int().NotNull()
                .AddColumn("LastError", "Último Erro").Varchar(2000);


        }
        public record SendFileCommand(string IdempotencyKey, int ChunkIndex, bool IsFinalChunk, string FileName, string ContentType, Stream FileStream);
        public record SendFileResponse(bool Success, int ChunkIndex, bool IsFinalized);

    }
}
