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
    public class EmissaoFiscalTransporteQueryWrite : QueryBase, IEmissaoFiscalTransporteQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EmissaoFiscalTransporteQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEmissaoFiscalTransporteQuery(IEmissaoFiscalTransporteEntity EmissaoFiscalTransporte)
        {
            this.Query = $@" INSERT INTO [EmissaoFiscalTransporte] ([CorrelationId], [OrigemFluxo], [CargaId], [RomaneioId], [Ambiente], [EmitenteDocumento], [TomadorDocumento], [TransportadorDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [QuantidadeNFe], [QuantidadeCTe], [QuantidadeMDFe], [ValorCarga], [PesoBruto], [Volume], [UltimaMensagem], [CriadoEmUtc], [AtualizadoEmUtc], [ConcluidoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CorrelationId, @OrigemFluxo, @CargaId, @RomaneioId, @Ambiente, @EmitenteDocumento, @TomadorDocumento, @TransportadorDocumento, @UFInicio, @UFFim, @MunicipioInicioCodigoIbge, @MunicipioFimCodigoIbge, @QuantidadeNFe, @QuantidadeCTe, @QuantidadeMDFe, @ValorCarga, @PesoBruto, @Volume, @UltimaMensagem, @CriadoEmUtc, @AtualizadoEmUtc, @ConcluidoEmUtc, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CorrelationId = EmissaoFiscalTransporte.CorrelationId,
                OrigemFluxo = EmissaoFiscalTransporte.OrigemFluxo,
                CargaId = EmissaoFiscalTransporte.CargaId,
                RomaneioId = EmissaoFiscalTransporte.RomaneioId,
                Ambiente = EmissaoFiscalTransporte.Ambiente,
                EmitenteDocumento = EmissaoFiscalTransporte.EmitenteDocumento,
                TomadorDocumento = EmissaoFiscalTransporte.TomadorDocumento,
                TransportadorDocumento = EmissaoFiscalTransporte.TransportadorDocumento,
                UFInicio = EmissaoFiscalTransporte.UFInicio,
                UFFim = EmissaoFiscalTransporte.UFFim,
                MunicipioInicioCodigoIbge = EmissaoFiscalTransporte.MunicipioInicioCodigoIbge,
                MunicipioFimCodigoIbge = EmissaoFiscalTransporte.MunicipioFimCodigoIbge,
                QuantidadeNFe = EmissaoFiscalTransporte.QuantidadeNFe,
                QuantidadeCTe = EmissaoFiscalTransporte.QuantidadeCTe,
                QuantidadeMDFe = EmissaoFiscalTransporte.QuantidadeMDFe,
                ValorCarga = EmissaoFiscalTransporte.ValorCarga,
                PesoBruto = EmissaoFiscalTransporte.PesoBruto,
                Volume = EmissaoFiscalTransporte.Volume,
                UltimaMensagem = EmissaoFiscalTransporte.UltimaMensagem,
                CriadoEmUtc = EmissaoFiscalTransporte.CriadoEmUtc,
                AtualizadoEmUtc = EmissaoFiscalTransporte.AtualizadoEmUtc,
                ConcluidoEmUtc = EmissaoFiscalTransporte.ConcluidoEmUtc,
                Status = EmissaoFiscalTransporte.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmissaoFiscalTransporteQuery(IEmissaoFiscalTransporteEntity EmissaoFiscalTransporte)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [CorrelationId] = @CorrelationId, [OrigemFluxo] = @OrigemFluxo, [CargaId] = @CargaId, [RomaneioId] = @RomaneioId, [Ambiente] = @Ambiente, [EmitenteDocumento] = @EmitenteDocumento, [TomadorDocumento] = @TomadorDocumento, [TransportadorDocumento] = @TransportadorDocumento, [UFInicio] = @UFInicio, [UFFim] = @UFFim, [MunicipioInicioCodigoIbge] = @MunicipioInicioCodigoIbge, [MunicipioFimCodigoIbge] = @MunicipioFimCodigoIbge, [QuantidadeNFe] = @QuantidadeNFe, [QuantidadeCTe] = @QuantidadeCTe, [QuantidadeMDFe] = @QuantidadeMDFe, [ValorCarga] = @ValorCarga, [PesoBruto] = @PesoBruto, [Volume] = @Volume, [UltimaMensagem] = @UltimaMensagem, [CriadoEmUtc] = @CriadoEmUtc, [AtualizadoEmUtc] = @AtualizadoEmUtc, [ConcluidoEmUtc] = @ConcluidoEmUtc, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = EmissaoFiscalTransporte.CorrelationId,
                OrigemFluxo = EmissaoFiscalTransporte.OrigemFluxo,
                CargaId = EmissaoFiscalTransporte.CargaId,
                RomaneioId = EmissaoFiscalTransporte.RomaneioId,
                Ambiente = EmissaoFiscalTransporte.Ambiente,
                EmitenteDocumento = EmissaoFiscalTransporte.EmitenteDocumento,
                TomadorDocumento = EmissaoFiscalTransporte.TomadorDocumento,
                TransportadorDocumento = EmissaoFiscalTransporte.TransportadorDocumento,
                UFInicio = EmissaoFiscalTransporte.UFInicio,
                UFFim = EmissaoFiscalTransporte.UFFim,
                MunicipioInicioCodigoIbge = EmissaoFiscalTransporte.MunicipioInicioCodigoIbge,
                MunicipioFimCodigoIbge = EmissaoFiscalTransporte.MunicipioFimCodigoIbge,
                QuantidadeNFe = EmissaoFiscalTransporte.QuantidadeNFe,
                QuantidadeCTe = EmissaoFiscalTransporte.QuantidadeCTe,
                QuantidadeMDFe = EmissaoFiscalTransporte.QuantidadeMDFe,
                ValorCarga = EmissaoFiscalTransporte.ValorCarga,
                PesoBruto = EmissaoFiscalTransporte.PesoBruto,
                Volume = EmissaoFiscalTransporte.Volume,
                UltimaMensagem = EmissaoFiscalTransporte.UltimaMensagem,
                CriadoEmUtc = EmissaoFiscalTransporte.CriadoEmUtc,
                AtualizadoEmUtc = EmissaoFiscalTransporte.AtualizadoEmUtc,
                ConcluidoEmUtc = EmissaoFiscalTransporte.ConcluidoEmUtc,
                Status = EmissaoFiscalTransporte.Status,
                Changed = EmissaoFiscalTransporte.Changed,
                UserId = _executionContext.UserId,
                Id = EmissaoFiscalTransporte.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOrigemFluxo(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [OrigemFluxo] = @OrigemFluxo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OrigemFluxo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaId(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [CargaId] = @CargaId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CargaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRomaneioId(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [RomaneioId] = @RomaneioId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RomaneioId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAmbiente(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [Ambiente] = @Ambiente WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ambiente = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmitenteDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [EmitenteDocumento] = @EmitenteDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmitenteDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTomadorDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [TomadorDocumento] = @TomadorDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TomadorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTransportadorDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [TransportadorDocumento] = @TransportadorDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TransportadorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFInicio(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [UFInicio] = @UFInicio WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFInicio = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFFim(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [UFFim] = @UFFim WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFFim = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioInicioCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [MunicipioInicioCodigoIbge] = @MunicipioInicioCodigoIbge WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MunicipioInicioCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioFimCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [MunicipioFimCodigoIbge] = @MunicipioFimCodigoIbge WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MunicipioFimCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadeNFe(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [QuantidadeNFe] = @QuantidadeNFe WHERE [Id] = @Id ";
            this.Parameters = new
            {
                QuantidadeNFe = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadeCTe(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [QuantidadeCTe] = @QuantidadeCTe WHERE [Id] = @Id ";
            this.Parameters = new
            {
                QuantidadeCTe = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadeMDFe(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [QuantidadeMDFe] = @QuantidadeMDFe WHERE [Id] = @Id ";
            this.Parameters = new
            {
                QuantidadeMDFe = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorCarga(int id, Decimal value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [ValorCarga] = @ValorCarga WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValorCarga = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePesoBruto(int id, Decimal value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [PesoBruto] = @PesoBruto WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PesoBruto = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVolume(int id, Decimal value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [Volume] = @Volume WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Volume = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUltimaMensagem(int id, string value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [UltimaMensagem] = @UltimaMensagem WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UltimaMensagem = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCriadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [CriadoEmUtc] = @CriadoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CriadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAtualizadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [AtualizadoEmUtc] = @AtualizadoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AtualizadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateConcluidoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [ConcluidoEmUtc] = @ConcluidoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ConcluidoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [EmissaoFiscalTransporte] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEmissaoFiscalTransporteQuery(IEmissaoFiscalTransporteEntity EmissaoFiscalTransporte)
        {
            this.Query = $@" DELETE FROM [EmissaoFiscalTransporte] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = EmissaoFiscalTransporte.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration