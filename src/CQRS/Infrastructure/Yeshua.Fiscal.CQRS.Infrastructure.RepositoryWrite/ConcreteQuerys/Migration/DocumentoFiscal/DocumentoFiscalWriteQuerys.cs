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
    public class DocumentoFiscalQueryWrite : QueryBase, IDocumentoFiscalQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public DocumentoFiscalQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirDocumentoFiscalQuery(IDocumentoFiscalEntity DocumentoFiscal)
        {
            this.Query = $@" INSERT INTO [DocumentoFiscal] ([CorrelationId], [ProdutoFiscal], [ChaveAcesso], [Serie], [Numero], [Ambiente], [UFEmitente], [EmitenteDocumento], [DestinatarioDocumento], [XmlStorageKey], [XmlHash], [ProtocoloAutorizacao], [CodigoRetorno], [MensagemRetorno], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CorrelationId, @ProdutoFiscal, @ChaveAcesso, @Serie, @Numero, @Ambiente, @UFEmitente, @EmitenteDocumento, @DestinatarioDocumento, @XmlStorageKey, @XmlHash, @ProtocoloAutorizacao, @CodigoRetorno, @MensagemRetorno, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CorrelationId = DocumentoFiscal.CorrelationId,
                ProdutoFiscal = DocumentoFiscal.ProdutoFiscal,
                ChaveAcesso = DocumentoFiscal.ChaveAcesso,
                Serie = DocumentoFiscal.Serie,
                Numero = DocumentoFiscal.Numero,
                Ambiente = DocumentoFiscal.Ambiente,
                UFEmitente = DocumentoFiscal.UFEmitente,
                EmitenteDocumento = DocumentoFiscal.EmitenteDocumento,
                DestinatarioDocumento = DocumentoFiscal.DestinatarioDocumento,
                XmlStorageKey = DocumentoFiscal.XmlStorageKey,
                XmlHash = DocumentoFiscal.XmlHash,
                ProtocoloAutorizacao = DocumentoFiscal.ProtocoloAutorizacao,
                CodigoRetorno = DocumentoFiscal.CodigoRetorno,
                MensagemRetorno = DocumentoFiscal.MensagemRetorno,
                Status = DocumentoFiscal.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumentoFiscalQuery(IDocumentoFiscalEntity DocumentoFiscal)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [CorrelationId] = @CorrelationId, [ProdutoFiscal] = @ProdutoFiscal, [ChaveAcesso] = @ChaveAcesso, [Serie] = @Serie, [Numero] = @Numero, [Ambiente] = @Ambiente, [UFEmitente] = @UFEmitente, [EmitenteDocumento] = @EmitenteDocumento, [DestinatarioDocumento] = @DestinatarioDocumento, [XmlStorageKey] = @XmlStorageKey, [XmlHash] = @XmlHash, [ProtocoloAutorizacao] = @ProtocoloAutorizacao, [CodigoRetorno] = @CodigoRetorno, [MensagemRetorno] = @MensagemRetorno, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = DocumentoFiscal.CorrelationId,
                ProdutoFiscal = DocumentoFiscal.ProdutoFiscal,
                ChaveAcesso = DocumentoFiscal.ChaveAcesso,
                Serie = DocumentoFiscal.Serie,
                Numero = DocumentoFiscal.Numero,
                Ambiente = DocumentoFiscal.Ambiente,
                UFEmitente = DocumentoFiscal.UFEmitente,
                EmitenteDocumento = DocumentoFiscal.EmitenteDocumento,
                DestinatarioDocumento = DocumentoFiscal.DestinatarioDocumento,
                XmlStorageKey = DocumentoFiscal.XmlStorageKey,
                XmlHash = DocumentoFiscal.XmlHash,
                ProtocoloAutorizacao = DocumentoFiscal.ProtocoloAutorizacao,
                CodigoRetorno = DocumentoFiscal.CodigoRetorno,
                MensagemRetorno = DocumentoFiscal.MensagemRetorno,
                Status = DocumentoFiscal.Status,
                Changed = DocumentoFiscal.Changed,
                UserId = _executionContext.UserId,
                Id = DocumentoFiscal.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoFiscal(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [ProdutoFiscal] = @ProdutoFiscal WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ProdutoFiscal = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcesso(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [ChaveAcesso] = @ChaveAcesso WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSerie(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [Serie] = @Serie WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Serie = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNumero(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [Numero] = @Numero WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Numero = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAmbiente(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [Ambiente] = @Ambiente WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ambiente = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFEmitente(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [UFEmitente] = @UFEmitente WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFEmitente = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmitenteDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [EmitenteDocumento] = @EmitenteDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmitenteDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDestinatarioDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [DestinatarioDocumento] = @DestinatarioDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DestinatarioDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateXmlStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [XmlStorageKey] = @XmlStorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                XmlStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateXmlHash(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [XmlHash] = @XmlHash WHERE [Id] = @Id ";
            this.Parameters = new
            {
                XmlHash = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProtocoloAutorizacao(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [ProtocoloAutorizacao] = @ProtocoloAutorizacao WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ProtocoloAutorizacao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCodigoRetorno(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [CodigoRetorno] = @CodigoRetorno WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CodigoRetorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMensagemRetorno(int id, string value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [MensagemRetorno] = @MensagemRetorno WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MensagemRetorno = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [DocumentoFiscal] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteDocumentoFiscalQuery(IDocumentoFiscalEntity DocumentoFiscal)
        {
            this.Query = $@" DELETE FROM [DocumentoFiscal] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = DocumentoFiscal.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration