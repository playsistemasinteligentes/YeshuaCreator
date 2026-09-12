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
    public class EmissaoFiscalTransporteDocumentoQueryWrite : QueryBase, IEmissaoFiscalTransporteDocumentoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EmissaoFiscalTransporteDocumentoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEmissaoFiscalTransporteDocumentoQuery(IEmissaoFiscalTransporteDocumentoEntity EmissaoFiscalTransporteDocumento)
        {
            this.Query = $@" INSERT INTO [EmissaoFiscalTransporteDocumento] ([EmissaoFiscalTransporteId], [DocumentoFiscalId], [DocumentoFiscalOriginarioId], [NFeProdutoSnapshotId], [ProdutoFiscal], [Papel], [TipoEvento], [ChaveAcesso], [XmlStorageKey], [PdfStorageKey], [Protocolo], [CodigoRetorno], [MensagemRetorno], [CriadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@EmissaoFiscalTransporteId, @DocumentoFiscalId, @DocumentoFiscalOriginarioId, @NFeProdutoSnapshotId, @ProdutoFiscal, @Papel, @TipoEvento, @ChaveAcesso, @XmlStorageKey, @PdfStorageKey, @Protocolo, @CodigoRetorno, @MensagemRetorno, @CriadoEmUtc, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                EmissaoFiscalTransporteId = EmissaoFiscalTransporteDocumento.EmissaoFiscalTransporteId,
                DocumentoFiscalId = EmissaoFiscalTransporteDocumento.DocumentoFiscalId,
                DocumentoFiscalOriginarioId = EmissaoFiscalTransporteDocumento.DocumentoFiscalOriginarioId,
                NFeProdutoSnapshotId = EmissaoFiscalTransporteDocumento.NFeProdutoSnapshotId,
                ProdutoFiscal = EmissaoFiscalTransporteDocumento.ProdutoFiscal,
                Papel = EmissaoFiscalTransporteDocumento.Papel,
                TipoEvento = EmissaoFiscalTransporteDocumento.TipoEvento,
                ChaveAcesso = EmissaoFiscalTransporteDocumento.ChaveAcesso,
                XmlStorageKey = EmissaoFiscalTransporteDocumento.XmlStorageKey,
                PdfStorageKey = EmissaoFiscalTransporteDocumento.PdfStorageKey,
                Protocolo = EmissaoFiscalTransporteDocumento.Protocolo,
                CodigoRetorno = EmissaoFiscalTransporteDocumento.CodigoRetorno,
                MensagemRetorno = EmissaoFiscalTransporteDocumento.MensagemRetorno,
                CriadoEmUtc = EmissaoFiscalTransporteDocumento.CriadoEmUtc,
                Status = EmissaoFiscalTransporteDocumento.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmissaoFiscalTransporteDocumentoQuery(IEmissaoFiscalTransporteDocumentoEntity EmissaoFiscalTransporteDocumento)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [EmissaoFiscalTransporteId] = @EmissaoFiscalTransporteId, [DocumentoFiscalId] = @DocumentoFiscalId, [DocumentoFiscalOriginarioId] = @DocumentoFiscalOriginarioId, [NFeProdutoSnapshotId] = @NFeProdutoSnapshotId, [ProdutoFiscal] = @ProdutoFiscal, [Papel] = @Papel, [TipoEvento] = @TipoEvento, [ChaveAcesso] = @ChaveAcesso, [XmlStorageKey] = @XmlStorageKey, [PdfStorageKey] = @PdfStorageKey, [Protocolo] = @Protocolo, [CodigoRetorno] = @CodigoRetorno, [MensagemRetorno] = @MensagemRetorno, [CriadoEmUtc] = @CriadoEmUtc, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmissaoFiscalTransporteId = EmissaoFiscalTransporteDocumento.EmissaoFiscalTransporteId,
                DocumentoFiscalId = EmissaoFiscalTransporteDocumento.DocumentoFiscalId,
                DocumentoFiscalOriginarioId = EmissaoFiscalTransporteDocumento.DocumentoFiscalOriginarioId,
                NFeProdutoSnapshotId = EmissaoFiscalTransporteDocumento.NFeProdutoSnapshotId,
                ProdutoFiscal = EmissaoFiscalTransporteDocumento.ProdutoFiscal,
                Papel = EmissaoFiscalTransporteDocumento.Papel,
                TipoEvento = EmissaoFiscalTransporteDocumento.TipoEvento,
                ChaveAcesso = EmissaoFiscalTransporteDocumento.ChaveAcesso,
                XmlStorageKey = EmissaoFiscalTransporteDocumento.XmlStorageKey,
                PdfStorageKey = EmissaoFiscalTransporteDocumento.PdfStorageKey,
                Protocolo = EmissaoFiscalTransporteDocumento.Protocolo,
                CodigoRetorno = EmissaoFiscalTransporteDocumento.CodigoRetorno,
                MensagemRetorno = EmissaoFiscalTransporteDocumento.MensagemRetorno,
                CriadoEmUtc = EmissaoFiscalTransporteDocumento.CriadoEmUtc,
                Status = EmissaoFiscalTransporteDocumento.Status,
                Changed = EmissaoFiscalTransporteDocumento.Changed,
                UserId = _executionContext.UserId,
                Id = EmissaoFiscalTransporteDocumento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmissaoFiscalTransporteId(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [EmissaoFiscalTransporteId] = @EmissaoFiscalTransporteId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmissaoFiscalTransporteId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumentoFiscalId(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [DocumentoFiscalId] = @DocumentoFiscalId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DocumentoFiscalId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumentoFiscalOriginarioId(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [DocumentoFiscalOriginarioId] = @DocumentoFiscalOriginarioId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DocumentoFiscalOriginarioId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNFeProdutoSnapshotId(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [NFeProdutoSnapshotId] = @NFeProdutoSnapshotId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                NFeProdutoSnapshotId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoFiscal(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [ProdutoFiscal] = @ProdutoFiscal WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ProdutoFiscal = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePapel(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [Papel] = @Papel WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Papel = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoEvento(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [TipoEvento] = @TipoEvento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TipoEvento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcesso(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [ChaveAcesso] = @ChaveAcesso WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateXmlStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [XmlStorageKey] = @XmlStorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                XmlStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePdfStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [PdfStorageKey] = @PdfStorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PdfStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProtocolo(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [Protocolo] = @Protocolo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Protocolo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCodigoRetorno(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [CodigoRetorno] = @CodigoRetorno WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CodigoRetorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMensagemRetorno(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [MensagemRetorno] = @MensagemRetorno WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MensagemRetorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCriadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [CriadoEmUtc] = @CriadoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CriadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporteDocumento] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEmissaoFiscalTransporteDocumentoQuery(IEmissaoFiscalTransporteDocumentoEntity EmissaoFiscalTransporteDocumento)
        {
            this.Query = $@" DELETE FROM [EmissaoFiscalTransporteDocumento] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = EmissaoFiscalTransporteDocumento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration