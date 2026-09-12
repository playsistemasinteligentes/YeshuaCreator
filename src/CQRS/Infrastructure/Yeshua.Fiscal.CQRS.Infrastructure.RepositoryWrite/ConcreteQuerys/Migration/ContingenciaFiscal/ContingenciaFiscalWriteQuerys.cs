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
    public class ContingenciaFiscalQueryWrite : QueryBase, IContingenciaFiscalQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ContingenciaFiscalQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirContingenciaFiscalQuery(IContingenciaFiscalEntity ContingenciaFiscal)
        {
            this.Query = $@" INSERT INTO [ContingenciaFiscal] ([EmissaoFiscalTransporteId], [EntradaFiscalContingenciaId], [CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [QuantidadeDocumentos], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@EmissaoFiscalTransporteId, @EntradaFiscalContingenciaId, @CorrelationId, @CargaId, @TipoSolicitante, @Ambiente, @EmitenteDocumento, @TomadorDocumento, @TransportadorDocumento, @QuantidadeDocumentos, @QuantidadeCTe, @QuantidadeMDFe, @ValorCarga, @PesoBruto, @UltimaMensagem, @CriadoEmUtc, @AtualizadoEmUtc, @ConcluidoEmUtc, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                EmissaoFiscalTransporteId = ContingenciaFiscal.EmissaoFiscalTransporteId,
                EntradaFiscalContingenciaId = ContingenciaFiscal.EntradaFiscalContingenciaId,
                CorrelationId = ContingenciaFiscal.CorrelationId,
                CargaId = ContingenciaFiscal.CargaId,
                TipoSolicitante = ContingenciaFiscal.TipoSolicitante,
                Ambiente = ContingenciaFiscal.Ambiente,
                EmitenteDocumento = ContingenciaFiscal.EmitenteDocumento,
                TomadorDocumento = ContingenciaFiscal.TomadorDocumento,
                TransportadorDocumento = ContingenciaFiscal.TransportadorDocumento,
                QuantidadeDocumentos = ContingenciaFiscal.QuantidadeDocumentos,
                QuantidadeCTe = ContingenciaFiscal.QuantidadeCTe,
                QuantidadeMDFe = ContingenciaFiscal.QuantidadeMDFe,
                ValorCarga = ContingenciaFiscal.ValorCarga,
                PesoBruto = ContingenciaFiscal.PesoBruto,
                UltimaMensagem = ContingenciaFiscal.UltimaMensagem,
                CriadoEmUtc = ContingenciaFiscal.CriadoEmUtc,
                AtualizadoEmUtc = ContingenciaFiscal.AtualizadoEmUtc,
                ConcluidoEmUtc = ContingenciaFiscal.ConcluidoEmUtc,
                Status = ContingenciaFiscal.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateContingenciaFiscalQuery(IContingenciaFiscalEntity ContingenciaFiscal)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [EmissaoFiscalTransporteId] = @EmissaoFiscalTransporteId, [EntradaFiscalContingenciaId] = @EntradaFiscalContingenciaId, [CorrelationId] = @CorrelationId, [CargaId] = @CargaId, [TipoSolicitante] = @TipoSolicitante, [Ambiente] = @Ambiente, [EmitenteDocumento] = @EmitenteDocumento, [TomadorDocumento] = @TomadorDocumento, [TransportadorDocumento] = @TransportadorDocumento, [QuantidadeDocumentos] = @QuantidadeDocumentos, [QuantidadeCTe] = @QuantidadeCTe, [QuantidadeMDFe] = @QuantidadeMDFe, [ValorCarga] = @ValorCarga, [PesoBruto] = @PesoBruto, [UltimaMensagem] = @UltimaMensagem, [CriadoEmUtc] = @CriadoEmUtc, [AtualizadoEmUtc] = @AtualizadoEmUtc, [ConcluidoEmUtc] = @ConcluidoEmUtc, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmissaoFiscalTransporteId = ContingenciaFiscal.EmissaoFiscalTransporteId,
                EntradaFiscalContingenciaId = ContingenciaFiscal.EntradaFiscalContingenciaId,
                CorrelationId = ContingenciaFiscal.CorrelationId,
                CargaId = ContingenciaFiscal.CargaId,
                TipoSolicitante = ContingenciaFiscal.TipoSolicitante,
                Ambiente = ContingenciaFiscal.Ambiente,
                EmitenteDocumento = ContingenciaFiscal.EmitenteDocumento,
                TomadorDocumento = ContingenciaFiscal.TomadorDocumento,
                TransportadorDocumento = ContingenciaFiscal.TransportadorDocumento,
                QuantidadeDocumentos = ContingenciaFiscal.QuantidadeDocumentos,
                QuantidadeCTe = ContingenciaFiscal.QuantidadeCTe,
                QuantidadeMDFe = ContingenciaFiscal.QuantidadeMDFe,
                ValorCarga = ContingenciaFiscal.ValorCarga,
                PesoBruto = ContingenciaFiscal.PesoBruto,
                UltimaMensagem = ContingenciaFiscal.UltimaMensagem,
                CriadoEmUtc = ContingenciaFiscal.CriadoEmUtc,
                AtualizadoEmUtc = ContingenciaFiscal.AtualizadoEmUtc,
                ConcluidoEmUtc = ContingenciaFiscal.ConcluidoEmUtc,
                Status = ContingenciaFiscal.Status,
                Changed = ContingenciaFiscal.Changed,
                UserId = _executionContext.UserId,
                Id = ContingenciaFiscal.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmissaoFiscalTransporteId(int id, int value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [EmissaoFiscalTransporteId] = @EmissaoFiscalTransporteId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmissaoFiscalTransporteId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntradaFiscalContingenciaId(int id, int value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [EntradaFiscalContingenciaId] = @EntradaFiscalContingenciaId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EntradaFiscalContingenciaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaId(int id, string value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [CargaId] = @CargaId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CargaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoSolicitante(int id, int value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [TipoSolicitante] = @TipoSolicitante WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TipoSolicitante = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAmbiente(int id, int value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [Ambiente] = @Ambiente WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ambiente = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmitenteDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [EmitenteDocumento] = @EmitenteDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmitenteDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTomadorDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [TomadorDocumento] = @TomadorDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TomadorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTransportadorDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [TransportadorDocumento] = @TransportadorDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TransportadorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadeDocumentos(int id, int value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [QuantidadeDocumentos] = @QuantidadeDocumentos WHERE [Id] = @Id ";
            this.Parameters = new
            {
                QuantidadeDocumentos = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadeCTe(int id, int value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [QuantidadeCTe] = @QuantidadeCTe WHERE [Id] = @Id ";
            this.Parameters = new
            {
                QuantidadeCTe = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadeMDFe(int id, int value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [QuantidadeMDFe] = @QuantidadeMDFe WHERE [Id] = @Id ";
            this.Parameters = new
            {
                QuantidadeMDFe = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorCarga(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [ValorCarga] = @ValorCarga WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValorCarga = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePesoBruto(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [PesoBruto] = @PesoBruto WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PesoBruto = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUltimaMensagem(int id, string value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [UltimaMensagem] = @UltimaMensagem WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UltimaMensagem = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCriadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [CriadoEmUtc] = @CriadoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CriadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAtualizadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [AtualizadoEmUtc] = @AtualizadoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AtualizadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateConcluidoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [ConcluidoEmUtc] = @ConcluidoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ConcluidoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ContingenciaFiscal] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteContingenciaFiscalQuery(IContingenciaFiscalEntity ContingenciaFiscal)
        {
            this.Query = $@" DELETE FROM [ContingenciaFiscal] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ContingenciaFiscal.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration