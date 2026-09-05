// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class DocumentoFiscalOriginarioQueryWrite : QueryBase, IDocumentoFiscalOriginarioQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public DocumentoFiscalOriginarioQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirDocumentoFiscalOriginarioQuery(IDocumentoFiscalOriginarioEntity DocumentoFiscalOriginario)
        {
            this.Query = $@" INSERT INTO [DocumentoFiscalOriginario] ([DocumentoFiscalId], [CorrelationId], [SourceApplication], [SourceModule], [SourceMessageId], [TipoDocumento], [ChaveAcesso], [Numero], [Serie], [EmitenteDocumento], [DestinatarioDocumento], [ValorDocumento], [PesoBruto], [Volume], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@DocumentoFiscalId, @CorrelationId, @SourceApplication, @SourceModule, @SourceMessageId, @TipoDocumento, @ChaveAcesso, @Numero, @Serie, @EmitenteDocumento, @DestinatarioDocumento, @ValorDocumento, @PesoBruto, @Volume, @SnapshotJson, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                DocumentoFiscalId = DocumentoFiscalOriginario.DocumentoFiscalId,
                CorrelationId = DocumentoFiscalOriginario.CorrelationId,
                SourceApplication = DocumentoFiscalOriginario.SourceApplication,
                SourceModule = DocumentoFiscalOriginario.SourceModule,
                SourceMessageId = DocumentoFiscalOriginario.SourceMessageId,
                TipoDocumento = DocumentoFiscalOriginario.TipoDocumento,
                ChaveAcesso = DocumentoFiscalOriginario.ChaveAcesso,
                Numero = DocumentoFiscalOriginario.Numero,
                Serie = DocumentoFiscalOriginario.Serie,
                EmitenteDocumento = DocumentoFiscalOriginario.EmitenteDocumento,
                DestinatarioDocumento = DocumentoFiscalOriginario.DestinatarioDocumento,
                ValorDocumento = DocumentoFiscalOriginario.ValorDocumento,
                PesoBruto = DocumentoFiscalOriginario.PesoBruto,
                Volume = DocumentoFiscalOriginario.Volume,
                SnapshotJson = DocumentoFiscalOriginario.SnapshotJson,
                Status = DocumentoFiscalOriginario.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumentoFiscalOriginarioQuery(IDocumentoFiscalOriginarioEntity DocumentoFiscalOriginario)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [DocumentoFiscalId] = @DocumentoFiscalId, [CorrelationId] = @CorrelationId, [SourceApplication] = @SourceApplication, [SourceModule] = @SourceModule, [SourceMessageId] = @SourceMessageId, [TipoDocumento] = @TipoDocumento, [ChaveAcesso] = @ChaveAcesso, [Numero] = @Numero, [Serie] = @Serie, [EmitenteDocumento] = @EmitenteDocumento, [DestinatarioDocumento] = @DestinatarioDocumento, [ValorDocumento] = @ValorDocumento, [PesoBruto] = @PesoBruto, [Volume] = @Volume, [SnapshotJson] = @SnapshotJson, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DocumentoFiscalId = DocumentoFiscalOriginario.DocumentoFiscalId,
                CorrelationId = DocumentoFiscalOriginario.CorrelationId,
                SourceApplication = DocumentoFiscalOriginario.SourceApplication,
                SourceModule = DocumentoFiscalOriginario.SourceModule,
                SourceMessageId = DocumentoFiscalOriginario.SourceMessageId,
                TipoDocumento = DocumentoFiscalOriginario.TipoDocumento,
                ChaveAcesso = DocumentoFiscalOriginario.ChaveAcesso,
                Numero = DocumentoFiscalOriginario.Numero,
                Serie = DocumentoFiscalOriginario.Serie,
                EmitenteDocumento = DocumentoFiscalOriginario.EmitenteDocumento,
                DestinatarioDocumento = DocumentoFiscalOriginario.DestinatarioDocumento,
                ValorDocumento = DocumentoFiscalOriginario.ValorDocumento,
                PesoBruto = DocumentoFiscalOriginario.PesoBruto,
                Volume = DocumentoFiscalOriginario.Volume,
                SnapshotJson = DocumentoFiscalOriginario.SnapshotJson,
                Status = DocumentoFiscalOriginario.Status,
                Changed = DocumentoFiscalOriginario.Changed,
                UserId = _executionContext.UserId,
                Id = DocumentoFiscalOriginario.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumentoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [DocumentoFiscalId] = @DocumentoFiscalId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DocumentoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSourceApplication(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [SourceApplication] = @SourceApplication WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SourceApplication = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSourceModule(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [SourceModule] = @SourceModule WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SourceModule = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSourceMessageId(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [SourceMessageId] = @SourceMessageId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SourceMessageId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [TipoDocumento] = @TipoDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TipoDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcesso(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [ChaveAcesso] = @ChaveAcesso WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNumero(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [Numero] = @Numero WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Numero = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSerie(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [Serie] = @Serie WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Serie = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmitenteDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [EmitenteDocumento] = @EmitenteDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmitenteDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDestinatarioDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [DestinatarioDocumento] = @DestinatarioDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DestinatarioDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorDocumento(int id, Decimal value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [ValorDocumento] = @ValorDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePesoBruto(int id, Decimal value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [PesoBruto] = @PesoBruto WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PesoBruto = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVolume(int id, Decimal value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [Volume] = @Volume WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Volume = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSnapshotJson(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [SnapshotJson] = @SnapshotJson WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SnapshotJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscalOriginario] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteDocumentoFiscalOriginarioQuery(IDocumentoFiscalOriginarioEntity DocumentoFiscalOriginario)
        {
            this.Query = $@" DELETE FROM [DocumentoFiscalOriginario] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = DocumentoFiscalOriginario.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration