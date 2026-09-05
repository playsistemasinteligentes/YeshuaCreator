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
    public class CargaPlanejavelQueryWrite : QueryBase, ICargaPlanejavelQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CargaPlanejavelQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCargaPlanejavelQuery(ICargaPlanejavelEntity CargaPlanejavel)
        {
            this.Query = $@" INSERT INTO [CargaPlanejavel] ([CargaId], [Status], [TransportadoraId], [VeiculoId], [TipoVeiculoId], [PesoTeorico], [VolumeTeorico], [InicioJanelaEmbarque], [FimJanelaEmbarque], [EmbarqueAlvo], [QuantidadePedidos], [AlertasResumo]) VALUES(@CargaId, @Status, @TransportadoraId, @VeiculoId, @TipoVeiculoId, @PesoTeorico, @VolumeTeorico, @InicioJanelaEmbarque, @FimJanelaEmbarque, @EmbarqueAlvo, @QuantidadePedidos, @AlertasResumo) ";
            this.Parameters = new
            {
                CargaId = CargaPlanejavel.CargaId,
                Status = CargaPlanejavel.Status,
                TransportadoraId = CargaPlanejavel.TransportadoraId,
                VeiculoId = CargaPlanejavel.VeiculoId,
                TipoVeiculoId = CargaPlanejavel.TipoVeiculoId,
                PesoTeorico = CargaPlanejavel.PesoTeorico,
                VolumeTeorico = CargaPlanejavel.VolumeTeorico,
                InicioJanelaEmbarque = CargaPlanejavel.InicioJanelaEmbarque,
                FimJanelaEmbarque = CargaPlanejavel.FimJanelaEmbarque,
                EmbarqueAlvo = CargaPlanejavel.EmbarqueAlvo,
                QuantidadePedidos = CargaPlanejavel.QuantidadePedidos,
                AlertasResumo = CargaPlanejavel.AlertasResumo,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaPlanejavelQuery(ICargaPlanejavelEntity CargaPlanejavel)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [Status] = @Status, [TransportadoraId] = @TransportadoraId, [VeiculoId] = @VeiculoId, [TipoVeiculoId] = @TipoVeiculoId, [PesoTeorico] = @PesoTeorico, [VolumeTeorico] = @VolumeTeorico, [InicioJanelaEmbarque] = @InicioJanelaEmbarque, [FimJanelaEmbarque] = @FimJanelaEmbarque, [EmbarqueAlvo] = @EmbarqueAlvo, [QuantidadePedidos] = @QuantidadePedidos, [AlertasResumo] = @AlertasResumo WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                Status = CargaPlanejavel.Status,
                TransportadoraId = CargaPlanejavel.TransportadoraId,
                VeiculoId = CargaPlanejavel.VeiculoId,
                TipoVeiculoId = CargaPlanejavel.TipoVeiculoId,
                PesoTeorico = CargaPlanejavel.PesoTeorico,
                VolumeTeorico = CargaPlanejavel.VolumeTeorico,
                InicioJanelaEmbarque = CargaPlanejavel.InicioJanelaEmbarque,
                FimJanelaEmbarque = CargaPlanejavel.FimJanelaEmbarque,
                EmbarqueAlvo = CargaPlanejavel.EmbarqueAlvo,
                QuantidadePedidos = CargaPlanejavel.QuantidadePedidos,
                AlertasResumo = CargaPlanejavel.AlertasResumo,
                CargaId = CargaPlanejavel.CargaId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(string cargaid, string value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [Status] = @Status WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                Status = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTransportadoraId(string cargaid, string value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [TransportadoraId] = @TransportadoraId WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                TransportadoraId = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVeiculoId(string cargaid, string value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [VeiculoId] = @VeiculoId WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                VeiculoId = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoVeiculoId(string cargaid, int value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [TipoVeiculoId] = @TipoVeiculoId WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                TipoVeiculoId = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePesoTeorico(string cargaid, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [PesoTeorico] = @PesoTeorico WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                PesoTeorico = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVolumeTeorico(string cargaid, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [VolumeTeorico] = @VolumeTeorico WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                VolumeTeorico = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateInicioJanelaEmbarque(string cargaid, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [InicioJanelaEmbarque] = @InicioJanelaEmbarque WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                InicioJanelaEmbarque = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFimJanelaEmbarque(string cargaid, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [FimJanelaEmbarque] = @FimJanelaEmbarque WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                FimJanelaEmbarque = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmbarqueAlvo(string cargaid, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [EmbarqueAlvo] = @EmbarqueAlvo WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                EmbarqueAlvo = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadePedidos(string cargaid, int value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [QuantidadePedidos] = @QuantidadePedidos WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                QuantidadePedidos = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAlertasResumo(string cargaid, string value)
        {
            this.Query = $@" UPDATE [CargaPlanejavel] SET [AlertasResumo] = @AlertasResumo WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                AlertasResumo = value,
                CargaId = cargaid,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCargaPlanejavelQuery(ICargaPlanejavelEntity CargaPlanejavel)
        {
            this.Query = $@" DELETE FROM [CargaPlanejavel] WHERE [CargaId] = @CargaId ";
            this.Parameters = new
            {
                CargaId = CargaPlanejavel.CargaId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration