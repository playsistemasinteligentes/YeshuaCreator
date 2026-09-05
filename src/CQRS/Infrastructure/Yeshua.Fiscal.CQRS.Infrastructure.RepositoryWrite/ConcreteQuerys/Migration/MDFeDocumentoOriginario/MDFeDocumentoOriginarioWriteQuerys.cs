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
    public class MDFeDocumentoOriginarioQueryWrite : QueryBase, IMDFeDocumentoOriginarioQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MDFeDocumentoOriginarioQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMDFeDocumentoOriginarioQuery(IMDFeDocumentoOriginarioEntity MDFeDocumentoOriginario)
        {
            this.Query = $@" INSERT INTO [MDFeDocumentoOriginario] ([MDFeSolicitacaoFiscalId], [DocumentoFiscalOriginarioId], [TipoDocumento], [ChaveAcesso], [SnapshotJson], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@MDFeSolicitacaoFiscalId, @DocumentoFiscalOriginarioId, @TipoDocumento, @ChaveAcesso, @SnapshotJson, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = MDFeDocumentoOriginario.MDFeSolicitacaoFiscalId,
                DocumentoFiscalOriginarioId = MDFeDocumentoOriginario.DocumentoFiscalOriginarioId,
                TipoDocumento = MDFeDocumentoOriginario.TipoDocumento,
                ChaveAcesso = MDFeDocumentoOriginario.ChaveAcesso,
                SnapshotJson = MDFeDocumentoOriginario.SnapshotJson,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeDocumentoOriginarioQuery(IMDFeDocumentoOriginarioEntity MDFeDocumentoOriginario)
        {
            this.Query = $@" UPDATE [MDFeDocumentoOriginario] SET [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId, [DocumentoFiscalOriginarioId] = @DocumentoFiscalOriginarioId, [TipoDocumento] = @TipoDocumento, [ChaveAcesso] = @ChaveAcesso, [SnapshotJson] = @SnapshotJson, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = MDFeDocumentoOriginario.MDFeSolicitacaoFiscalId,
                DocumentoFiscalOriginarioId = MDFeDocumentoOriginario.DocumentoFiscalOriginarioId,
                TipoDocumento = MDFeDocumentoOriginario.TipoDocumento,
                ChaveAcesso = MDFeDocumentoOriginario.ChaveAcesso,
                SnapshotJson = MDFeDocumentoOriginario.SnapshotJson,
                Changed = MDFeDocumentoOriginario.Changed,
                UserId = _executionContext.UserId,
                Id = MDFeDocumentoOriginario.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeSolicitacaoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeDocumentoOriginario] SET [MDFeSolicitacaoFiscalId] = @MDFeSolicitacaoFiscalId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MDFeSolicitacaoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumentoFiscalOriginarioId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeDocumentoOriginario] SET [DocumentoFiscalOriginarioId] = @DocumentoFiscalOriginarioId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DocumentoFiscalOriginarioId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeDocumentoOriginario] SET [TipoDocumento] = @TipoDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TipoDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcesso(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeDocumentoOriginario] SET [ChaveAcesso] = @ChaveAcesso WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSnapshotJson(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeDocumentoOriginario] SET [SnapshotJson] = @SnapshotJson WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SnapshotJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeDocumentoOriginario] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [MDFeDocumentoOriginario] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [MDFeDocumentoOriginario] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeDocumentoOriginario] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMDFeDocumentoOriginarioQuery(IMDFeDocumentoOriginarioEntity MDFeDocumentoOriginario)
        {
            this.Query = $@" DELETE FROM [MDFeDocumentoOriginario] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = MDFeDocumentoOriginario.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration