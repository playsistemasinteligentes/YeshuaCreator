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
    public class MDFeSolicitacaoFiscalQueryWrite : QueryBase, IMDFeSolicitacaoFiscalQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MDFeSolicitacaoFiscalQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMDFeSolicitacaoFiscalQuery(IMDFeSolicitacaoFiscalEntity MDFeSolicitacaoFiscal)
        {
            this.Query = $@" INSERT INTO [MDFeSolicitacaoFiscal] ([CorrelationId], [CargaId], [Ambiente], [UFCarregamento], [UFDescarregamento], [PlacaVeiculo], [CondutorDocumento], [DocumentosOriginariosJson], [TransporteSnapshotJson], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CorrelationId, @CargaId, @Ambiente, @UFCarregamento, @UFDescarregamento, @PlacaVeiculo, @CondutorDocumento, @DocumentosOriginariosJson, @TransporteSnapshotJson, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CorrelationId = MDFeSolicitacaoFiscal.CorrelationId,
                CargaId = MDFeSolicitacaoFiscal.CargaId,
                Ambiente = MDFeSolicitacaoFiscal.Ambiente,
                UFCarregamento = MDFeSolicitacaoFiscal.UFCarregamento,
                UFDescarregamento = MDFeSolicitacaoFiscal.UFDescarregamento,
                PlacaVeiculo = MDFeSolicitacaoFiscal.PlacaVeiculo,
                CondutorDocumento = MDFeSolicitacaoFiscal.CondutorDocumento,
                DocumentosOriginariosJson = MDFeSolicitacaoFiscal.DocumentosOriginariosJson,
                TransporteSnapshotJson = MDFeSolicitacaoFiscal.TransporteSnapshotJson,
                Status = MDFeSolicitacaoFiscal.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMDFeSolicitacaoFiscalQuery(IMDFeSolicitacaoFiscalEntity MDFeSolicitacaoFiscal)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [CorrelationId] = @CorrelationId, [CargaId] = @CargaId, [Ambiente] = @Ambiente, [UFCarregamento] = @UFCarregamento, [UFDescarregamento] = @UFDescarregamento, [PlacaVeiculo] = @PlacaVeiculo, [CondutorDocumento] = @CondutorDocumento, [DocumentosOriginariosJson] = @DocumentosOriginariosJson, [TransporteSnapshotJson] = @TransporteSnapshotJson, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = MDFeSolicitacaoFiscal.CorrelationId,
                CargaId = MDFeSolicitacaoFiscal.CargaId,
                Ambiente = MDFeSolicitacaoFiscal.Ambiente,
                UFCarregamento = MDFeSolicitacaoFiscal.UFCarregamento,
                UFDescarregamento = MDFeSolicitacaoFiscal.UFDescarregamento,
                PlacaVeiculo = MDFeSolicitacaoFiscal.PlacaVeiculo,
                CondutorDocumento = MDFeSolicitacaoFiscal.CondutorDocumento,
                DocumentosOriginariosJson = MDFeSolicitacaoFiscal.DocumentosOriginariosJson,
                TransporteSnapshotJson = MDFeSolicitacaoFiscal.TransporteSnapshotJson,
                Status = MDFeSolicitacaoFiscal.Status,
                Changed = MDFeSolicitacaoFiscal.Changed,
                UserId = _executionContext.UserId,
                Id = MDFeSolicitacaoFiscal.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaId(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [CargaId] = @CargaId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CargaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAmbiente(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [Ambiente] = @Ambiente WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ambiente = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFCarregamento(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [UFCarregamento] = @UFCarregamento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFCarregamento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFDescarregamento(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [UFDescarregamento] = @UFDescarregamento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFDescarregamento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePlacaVeiculo(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [PlacaVeiculo] = @PlacaVeiculo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PlacaVeiculo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCondutorDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [CondutorDocumento] = @CondutorDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CondutorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDocumentosOriginariosJson(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [DocumentosOriginariosJson] = @DocumentosOriginariosJson WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DocumentosOriginariosJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTransporteSnapshotJson(int id, string value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [TransporteSnapshotJson] = @TransporteSnapshotJson WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TransporteSnapshotJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [MDFeSolicitacaoFiscal] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMDFeSolicitacaoFiscalQuery(IMDFeSolicitacaoFiscalEntity MDFeSolicitacaoFiscal)
        {
            this.Query = $@" DELETE FROM [MDFeSolicitacaoFiscal] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = MDFeSolicitacaoFiscal.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration