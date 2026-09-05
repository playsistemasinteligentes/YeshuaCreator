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
    public class CTeSolicitacaoFiscalQueryWrite : QueryBase, ICTeSolicitacaoFiscalQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CTeSolicitacaoFiscalQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCTeSolicitacaoFiscalQuery(ICTeSolicitacaoFiscalEntity CTeSolicitacaoFiscal)
        {
            this.Query = $@" INSERT INTO [CTeSolicitacaoFiscal] ([EntradaOficialId], [RomaneioConsolidadoId], [CorrelationId], [Ambiente], [UFEmitente], [EmitenteDocumento], [ProdutoFiscal], [TipoCTe], [TipoServico], [Modal], [Globalizado], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [ValorServico], [ValorCarga], [PreferenciasManifestoJson], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@EntradaOficialId, @RomaneioConsolidadoId, @CorrelationId, @Ambiente, @UFEmitente, @EmitenteDocumento, @ProdutoFiscal, @TipoCTe, @TipoServico, @Modal, @Globalizado, @UFInicio, @UFFim, @MunicipioInicioCodigoIbge, @MunicipioFimCodigoIbge, @ValorServico, @ValorCarga, @PreferenciasManifestoJson, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                EntradaOficialId = CTeSolicitacaoFiscal.EntradaOficialId,
                RomaneioConsolidadoId = CTeSolicitacaoFiscal.RomaneioConsolidadoId,
                CorrelationId = CTeSolicitacaoFiscal.CorrelationId,
                Ambiente = CTeSolicitacaoFiscal.Ambiente,
                UFEmitente = CTeSolicitacaoFiscal.UFEmitente,
                EmitenteDocumento = CTeSolicitacaoFiscal.EmitenteDocumento,
                ProdutoFiscal = CTeSolicitacaoFiscal.ProdutoFiscal,
                TipoCTe = CTeSolicitacaoFiscal.TipoCTe,
                TipoServico = CTeSolicitacaoFiscal.TipoServico,
                Modal = CTeSolicitacaoFiscal.Modal,
                Globalizado = CTeSolicitacaoFiscal.Globalizado,
                UFInicio = CTeSolicitacaoFiscal.UFInicio,
                UFFim = CTeSolicitacaoFiscal.UFFim,
                MunicipioInicioCodigoIbge = CTeSolicitacaoFiscal.MunicipioInicioCodigoIbge,
                MunicipioFimCodigoIbge = CTeSolicitacaoFiscal.MunicipioFimCodigoIbge,
                ValorServico = CTeSolicitacaoFiscal.ValorServico,
                ValorCarga = CTeSolicitacaoFiscal.ValorCarga,
                PreferenciasManifestoJson = CTeSolicitacaoFiscal.PreferenciasManifestoJson,
                Status = CTeSolicitacaoFiscal.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeSolicitacaoFiscalQuery(ICTeSolicitacaoFiscalEntity CTeSolicitacaoFiscal)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [EntradaOficialId] = @EntradaOficialId, [RomaneioConsolidadoId] = @RomaneioConsolidadoId, [CorrelationId] = @CorrelationId, [Ambiente] = @Ambiente, [UFEmitente] = @UFEmitente, [EmitenteDocumento] = @EmitenteDocumento, [ProdutoFiscal] = @ProdutoFiscal, [TipoCTe] = @TipoCTe, [TipoServico] = @TipoServico, [Modal] = @Modal, [Globalizado] = @Globalizado, [UFInicio] = @UFInicio, [UFFim] = @UFFim, [MunicipioInicioCodigoIbge] = @MunicipioInicioCodigoIbge, [MunicipioFimCodigoIbge] = @MunicipioFimCodigoIbge, [ValorServico] = @ValorServico, [ValorCarga] = @ValorCarga, [PreferenciasManifestoJson] = @PreferenciasManifestoJson, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EntradaOficialId = CTeSolicitacaoFiscal.EntradaOficialId,
                RomaneioConsolidadoId = CTeSolicitacaoFiscal.RomaneioConsolidadoId,
                CorrelationId = CTeSolicitacaoFiscal.CorrelationId,
                Ambiente = CTeSolicitacaoFiscal.Ambiente,
                UFEmitente = CTeSolicitacaoFiscal.UFEmitente,
                EmitenteDocumento = CTeSolicitacaoFiscal.EmitenteDocumento,
                ProdutoFiscal = CTeSolicitacaoFiscal.ProdutoFiscal,
                TipoCTe = CTeSolicitacaoFiscal.TipoCTe,
                TipoServico = CTeSolicitacaoFiscal.TipoServico,
                Modal = CTeSolicitacaoFiscal.Modal,
                Globalizado = CTeSolicitacaoFiscal.Globalizado,
                UFInicio = CTeSolicitacaoFiscal.UFInicio,
                UFFim = CTeSolicitacaoFiscal.UFFim,
                MunicipioInicioCodigoIbge = CTeSolicitacaoFiscal.MunicipioInicioCodigoIbge,
                MunicipioFimCodigoIbge = CTeSolicitacaoFiscal.MunicipioFimCodigoIbge,
                ValorServico = CTeSolicitacaoFiscal.ValorServico,
                ValorCarga = CTeSolicitacaoFiscal.ValorCarga,
                PreferenciasManifestoJson = CTeSolicitacaoFiscal.PreferenciasManifestoJson,
                Status = CTeSolicitacaoFiscal.Status,
                Changed = CTeSolicitacaoFiscal.Changed,
                UserId = _executionContext.UserId,
                Id = CTeSolicitacaoFiscal.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntradaOficialId(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [EntradaOficialId] = @EntradaOficialId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EntradaOficialId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRomaneioConsolidadoId(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [RomaneioConsolidadoId] = @RomaneioConsolidadoId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RomaneioConsolidadoId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAmbiente(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [Ambiente] = @Ambiente WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ambiente = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFEmitente(int id, string value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [UFEmitente] = @UFEmitente WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFEmitente = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmitenteDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [EmitenteDocumento] = @EmitenteDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmitenteDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoFiscal(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [ProdutoFiscal] = @ProdutoFiscal WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ProdutoFiscal = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoCTe(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [TipoCTe] = @TipoCTe WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TipoCTe = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoServico(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [TipoServico] = @TipoServico WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TipoServico = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateModal(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [Modal] = @Modal WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Modal = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGlobalizado(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [Globalizado] = @Globalizado WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Globalizado = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFInicio(int id, string value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [UFInicio] = @UFInicio WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFInicio = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFFim(int id, string value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [UFFim] = @UFFim WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFFim = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioInicioCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [MunicipioInicioCodigoIbge] = @MunicipioInicioCodigoIbge WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MunicipioInicioCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioFimCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [MunicipioFimCodigoIbge] = @MunicipioFimCodigoIbge WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MunicipioFimCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorServico(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [ValorServico] = @ValorServico WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValorServico = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorCarga(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [ValorCarga] = @ValorCarga WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValorCarga = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePreferenciasManifestoJson(int id, string value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [PreferenciasManifestoJson] = @PreferenciasManifestoJson WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PreferenciasManifestoJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [CTeSolicitacaoFiscal] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCTeSolicitacaoFiscalQuery(ICTeSolicitacaoFiscalEntity CTeSolicitacaoFiscal)
        {
            this.Query = $@" DELETE FROM [CTeSolicitacaoFiscal] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = CTeSolicitacaoFiscal.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration