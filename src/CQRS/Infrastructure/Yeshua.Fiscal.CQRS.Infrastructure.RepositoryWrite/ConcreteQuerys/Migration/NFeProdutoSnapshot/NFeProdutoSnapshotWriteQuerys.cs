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
    public class NFeProdutoSnapshotQueryWrite : QueryBase, INFeProdutoSnapshotQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public NFeProdutoSnapshotQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirNFeProdutoSnapshotQuery(INFeProdutoSnapshotEntity NFeProdutoSnapshot)
        {
            this.Query = $@" INSERT INTO [NFeProdutoSnapshot] ([DocumentoFiscalOriginarioId], [CorrelationId], [CargaId], [PedidoId], [ChaveAcesso], [EmitenteDocumento], [DestinatarioDocumento], [UFOrigem], [UFDestino], [MunicipioOrigemCodigoIbge], [MunicipioDestinoCodigoIbge], [ValorDocumento], [PesoBruto], [Volume], [XmlStorageKey], [SnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@DocumentoFiscalOriginarioId, @CorrelationId, @CargaId, @PedidoId, @ChaveAcesso, @EmitenteDocumento, @DestinatarioDocumento, @UFOrigem, @UFDestino, @MunicipioOrigemCodigoIbge, @MunicipioDestinoCodigoIbge, @ValorDocumento, @PesoBruto, @Volume, @XmlStorageKey, @SnapshotJson, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                DocumentoFiscalOriginarioId = NFeProdutoSnapshot.DocumentoFiscalOriginarioId,
                CorrelationId = NFeProdutoSnapshot.CorrelationId,
                CargaId = NFeProdutoSnapshot.CargaId,
                PedidoId = NFeProdutoSnapshot.PedidoId,
                ChaveAcesso = NFeProdutoSnapshot.ChaveAcesso,
                EmitenteDocumento = NFeProdutoSnapshot.EmitenteDocumento,
                DestinatarioDocumento = NFeProdutoSnapshot.DestinatarioDocumento,
                UFOrigem = NFeProdutoSnapshot.UFOrigem,
                UFDestino = NFeProdutoSnapshot.UFDestino,
                MunicipioOrigemCodigoIbge = NFeProdutoSnapshot.MunicipioOrigemCodigoIbge,
                MunicipioDestinoCodigoIbge = NFeProdutoSnapshot.MunicipioDestinoCodigoIbge,
                ValorDocumento = NFeProdutoSnapshot.ValorDocumento,
                PesoBruto = NFeProdutoSnapshot.PesoBruto,
                Volume = NFeProdutoSnapshot.Volume,
                XmlStorageKey = NFeProdutoSnapshot.XmlStorageKey,
                SnapshotJson = NFeProdutoSnapshot.SnapshotJson,
                Status = NFeProdutoSnapshot.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNFeProdutoSnapshotQuery(INFeProdutoSnapshotEntity NFeProdutoSnapshot)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [DocumentoFiscalOriginarioId] = @DocumentoFiscalOriginarioId, [CorrelationId] = @CorrelationId, [CargaId] = @CargaId, [PedidoId] = @PedidoId, [ChaveAcesso] = @ChaveAcesso, [EmitenteDocumento] = @EmitenteDocumento, [DestinatarioDocumento] = @DestinatarioDocumento, [UFOrigem] = @UFOrigem, [UFDestino] = @UFDestino, [MunicipioOrigemCodigoIbge] = @MunicipioOrigemCodigoIbge, [MunicipioDestinoCodigoIbge] = @MunicipioDestinoCodigoIbge, [ValorDocumento] = @ValorDocumento, [PesoBruto] = @PesoBruto, [Volume] = @Volume, [XmlStorageKey] = @XmlStorageKey, [SnapshotJson] = @SnapshotJson, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DocumentoFiscalOriginarioId = NFeProdutoSnapshot.DocumentoFiscalOriginarioId,
                CorrelationId = NFeProdutoSnapshot.CorrelationId,
                CargaId = NFeProdutoSnapshot.CargaId,
                PedidoId = NFeProdutoSnapshot.PedidoId,
                ChaveAcesso = NFeProdutoSnapshot.ChaveAcesso,
                EmitenteDocumento = NFeProdutoSnapshot.EmitenteDocumento,
                DestinatarioDocumento = NFeProdutoSnapshot.DestinatarioDocumento,
                UFOrigem = NFeProdutoSnapshot.UFOrigem,
                UFDestino = NFeProdutoSnapshot.UFDestino,
                MunicipioOrigemCodigoIbge = NFeProdutoSnapshot.MunicipioOrigemCodigoIbge,
                MunicipioDestinoCodigoIbge = NFeProdutoSnapshot.MunicipioDestinoCodigoIbge,
                ValorDocumento = NFeProdutoSnapshot.ValorDocumento,
                PesoBruto = NFeProdutoSnapshot.PesoBruto,
                Volume = NFeProdutoSnapshot.Volume,
                XmlStorageKey = NFeProdutoSnapshot.XmlStorageKey,
                SnapshotJson = NFeProdutoSnapshot.SnapshotJson,
                Status = NFeProdutoSnapshot.Status,
                Changed = NFeProdutoSnapshot.Changed,
                UserId = _executionContext.UserId,
                Id = NFeProdutoSnapshot.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumentoFiscalOriginarioId(int id, int value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [DocumentoFiscalOriginarioId] = @DocumentoFiscalOriginarioId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DocumentoFiscalOriginarioId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaId(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [CargaId] = @CargaId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CargaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePedidoId(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [PedidoId] = @PedidoId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PedidoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChaveAcesso(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [ChaveAcesso] = @ChaveAcesso WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ChaveAcesso = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmitenteDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [EmitenteDocumento] = @EmitenteDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmitenteDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDestinatarioDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [DestinatarioDocumento] = @DestinatarioDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DestinatarioDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFOrigem(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [UFOrigem] = @UFOrigem WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFOrigem = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFDestino(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [UFDestino] = @UFDestino WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFDestino = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioOrigemCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [MunicipioOrigemCodigoIbge] = @MunicipioOrigemCodigoIbge WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MunicipioOrigemCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioDestinoCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [MunicipioDestinoCodigoIbge] = @MunicipioDestinoCodigoIbge WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MunicipioDestinoCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorDocumento(int id, Decimal value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [ValorDocumento] = @ValorDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePesoBruto(int id, Decimal value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [PesoBruto] = @PesoBruto WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PesoBruto = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVolume(int id, Decimal value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [Volume] = @Volume WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Volume = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateXmlStorageKey(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [XmlStorageKey] = @XmlStorageKey WHERE [Id] = @Id ";
            this.Parameters = new
            {
                XmlStorageKey = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSnapshotJson(int id, string value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [SnapshotJson] = @SnapshotJson WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SnapshotJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [NFeProdutoSnapshot] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteNFeProdutoSnapshotQuery(INFeProdutoSnapshotEntity NFeProdutoSnapshot)
        {
            this.Query = $@" DELETE FROM [NFeProdutoSnapshot] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = NFeProdutoSnapshot.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration