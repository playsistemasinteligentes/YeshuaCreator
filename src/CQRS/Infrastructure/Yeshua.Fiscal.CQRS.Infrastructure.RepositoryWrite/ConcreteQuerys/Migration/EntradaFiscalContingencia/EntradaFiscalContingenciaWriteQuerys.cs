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
    public class EntradaFiscalContingenciaQueryWrite : QueryBase, IEntradaFiscalContingenciaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EntradaFiscalContingenciaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEntradaFiscalContingenciaQuery(IEntradaFiscalContingenciaEntity EntradaFiscalContingencia)
        {
            this.Query = $@" INSERT INTO [EntradaFiscalContingencia] ([CorrelationId], [CargaId], [TipoSolicitante], [Ambiente], [SourceApplication], [SourceModule], [SourceMessageId], [EmitenteFiscalDocumento], [TomadorDocumento], [TransportadorDocumento], [RemetenteDocumento], [DestinatarioDocumento], [UFInicio], [UFFim], [MunicipioInicioCodigoIbge], [MunicipioFimCodigoIbge], [RNTRC], [PlacaVeiculo], [UFVeiculo], [CondutorDocumento], [CondutorNome], [QuantidadeDocumentos], [ValorCarga], [PesoBruto], [Volume], [PendenciasJson], [SnapshotJson], [EmissaoFiscalCorrelationId], [EmissaoFiscalSagaId], [CriadoEmUtc], [AtualizadoEmUtc], [Status], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CorrelationId, @CargaId, @TipoSolicitante, @Ambiente, @SourceApplication, @SourceModule, @SourceMessageId, @EmitenteFiscalDocumento, @TomadorDocumento, @TransportadorDocumento, @RemetenteDocumento, @DestinatarioDocumento, @UFInicio, @UFFim, @MunicipioInicioCodigoIbge, @MunicipioFimCodigoIbge, @RNTRC, @PlacaVeiculo, @UFVeiculo, @CondutorDocumento, @CondutorNome, @QuantidadeDocumentos, @ValorCarga, @PesoBruto, @Volume, @PendenciasJson, @SnapshotJson, @EmissaoFiscalCorrelationId, @EmissaoFiscalSagaId, @CriadoEmUtc, @AtualizadoEmUtc, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CorrelationId = EntradaFiscalContingencia.CorrelationId,
                CargaId = EntradaFiscalContingencia.CargaId,
                TipoSolicitante = EntradaFiscalContingencia.TipoSolicitante,
                Ambiente = EntradaFiscalContingencia.Ambiente,
                SourceApplication = EntradaFiscalContingencia.SourceApplication,
                SourceModule = EntradaFiscalContingencia.SourceModule,
                SourceMessageId = EntradaFiscalContingencia.SourceMessageId,
                EmitenteFiscalDocumento = EntradaFiscalContingencia.EmitenteFiscalDocumento,
                TomadorDocumento = EntradaFiscalContingencia.TomadorDocumento,
                TransportadorDocumento = EntradaFiscalContingencia.TransportadorDocumento,
                RemetenteDocumento = EntradaFiscalContingencia.RemetenteDocumento,
                DestinatarioDocumento = EntradaFiscalContingencia.DestinatarioDocumento,
                UFInicio = EntradaFiscalContingencia.UFInicio,
                UFFim = EntradaFiscalContingencia.UFFim,
                MunicipioInicioCodigoIbge = EntradaFiscalContingencia.MunicipioInicioCodigoIbge,
                MunicipioFimCodigoIbge = EntradaFiscalContingencia.MunicipioFimCodigoIbge,
                RNTRC = EntradaFiscalContingencia.RNTRC,
                PlacaVeiculo = EntradaFiscalContingencia.PlacaVeiculo,
                UFVeiculo = EntradaFiscalContingencia.UFVeiculo,
                CondutorDocumento = EntradaFiscalContingencia.CondutorDocumento,
                CondutorNome = EntradaFiscalContingencia.CondutorNome,
                QuantidadeDocumentos = EntradaFiscalContingencia.QuantidadeDocumentos,
                ValorCarga = EntradaFiscalContingencia.ValorCarga,
                PesoBruto = EntradaFiscalContingencia.PesoBruto,
                Volume = EntradaFiscalContingencia.Volume,
                PendenciasJson = EntradaFiscalContingencia.PendenciasJson,
                SnapshotJson = EntradaFiscalContingencia.SnapshotJson,
                EmissaoFiscalCorrelationId = EntradaFiscalContingencia.EmissaoFiscalCorrelationId,
                EmissaoFiscalSagaId = EntradaFiscalContingencia.EmissaoFiscalSagaId,
                CriadoEmUtc = EntradaFiscalContingencia.CriadoEmUtc,
                AtualizadoEmUtc = EntradaFiscalContingencia.AtualizadoEmUtc,
                Status = EntradaFiscalContingencia.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntradaFiscalContingenciaQuery(IEntradaFiscalContingenciaEntity EntradaFiscalContingencia)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [CorrelationId] = @CorrelationId, [CargaId] = @CargaId, [TipoSolicitante] = @TipoSolicitante, [Ambiente] = @Ambiente, [SourceApplication] = @SourceApplication, [SourceModule] = @SourceModule, [SourceMessageId] = @SourceMessageId, [EmitenteFiscalDocumento] = @EmitenteFiscalDocumento, [TomadorDocumento] = @TomadorDocumento, [TransportadorDocumento] = @TransportadorDocumento, [RemetenteDocumento] = @RemetenteDocumento, [DestinatarioDocumento] = @DestinatarioDocumento, [UFInicio] = @UFInicio, [UFFim] = @UFFim, [MunicipioInicioCodigoIbge] = @MunicipioInicioCodigoIbge, [MunicipioFimCodigoIbge] = @MunicipioFimCodigoIbge, [RNTRC] = @RNTRC, [PlacaVeiculo] = @PlacaVeiculo, [UFVeiculo] = @UFVeiculo, [CondutorDocumento] = @CondutorDocumento, [CondutorNome] = @CondutorNome, [QuantidadeDocumentos] = @QuantidadeDocumentos, [ValorCarga] = @ValorCarga, [PesoBruto] = @PesoBruto, [Volume] = @Volume, [PendenciasJson] = @PendenciasJson, [SnapshotJson] = @SnapshotJson, [EmissaoFiscalCorrelationId] = @EmissaoFiscalCorrelationId, [EmissaoFiscalSagaId] = @EmissaoFiscalSagaId, [CriadoEmUtc] = @CriadoEmUtc, [AtualizadoEmUtc] = @AtualizadoEmUtc, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = EntradaFiscalContingencia.CorrelationId,
                CargaId = EntradaFiscalContingencia.CargaId,
                TipoSolicitante = EntradaFiscalContingencia.TipoSolicitante,
                Ambiente = EntradaFiscalContingencia.Ambiente,
                SourceApplication = EntradaFiscalContingencia.SourceApplication,
                SourceModule = EntradaFiscalContingencia.SourceModule,
                SourceMessageId = EntradaFiscalContingencia.SourceMessageId,
                EmitenteFiscalDocumento = EntradaFiscalContingencia.EmitenteFiscalDocumento,
                TomadorDocumento = EntradaFiscalContingencia.TomadorDocumento,
                TransportadorDocumento = EntradaFiscalContingencia.TransportadorDocumento,
                RemetenteDocumento = EntradaFiscalContingencia.RemetenteDocumento,
                DestinatarioDocumento = EntradaFiscalContingencia.DestinatarioDocumento,
                UFInicio = EntradaFiscalContingencia.UFInicio,
                UFFim = EntradaFiscalContingencia.UFFim,
                MunicipioInicioCodigoIbge = EntradaFiscalContingencia.MunicipioInicioCodigoIbge,
                MunicipioFimCodigoIbge = EntradaFiscalContingencia.MunicipioFimCodigoIbge,
                RNTRC = EntradaFiscalContingencia.RNTRC,
                PlacaVeiculo = EntradaFiscalContingencia.PlacaVeiculo,
                UFVeiculo = EntradaFiscalContingencia.UFVeiculo,
                CondutorDocumento = EntradaFiscalContingencia.CondutorDocumento,
                CondutorNome = EntradaFiscalContingencia.CondutorNome,
                QuantidadeDocumentos = EntradaFiscalContingencia.QuantidadeDocumentos,
                ValorCarga = EntradaFiscalContingencia.ValorCarga,
                PesoBruto = EntradaFiscalContingencia.PesoBruto,
                Volume = EntradaFiscalContingencia.Volume,
                PendenciasJson = EntradaFiscalContingencia.PendenciasJson,
                SnapshotJson = EntradaFiscalContingencia.SnapshotJson,
                EmissaoFiscalCorrelationId = EntradaFiscalContingencia.EmissaoFiscalCorrelationId,
                EmissaoFiscalSagaId = EntradaFiscalContingencia.EmissaoFiscalSagaId,
                CriadoEmUtc = EntradaFiscalContingencia.CriadoEmUtc,
                AtualizadoEmUtc = EntradaFiscalContingencia.AtualizadoEmUtc,
                Status = EntradaFiscalContingencia.Status,
                Changed = EntradaFiscalContingencia.Changed,
                UserId = _executionContext.UserId,
                Id = EntradaFiscalContingencia.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [CorrelationId] = @CorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaId(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [CargaId] = @CargaId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CargaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoSolicitante(int id, int value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [TipoSolicitante] = @TipoSolicitante WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TipoSolicitante = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAmbiente(int id, int value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [Ambiente] = @Ambiente WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Ambiente = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSourceApplication(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [SourceApplication] = @SourceApplication WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SourceApplication = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSourceModule(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [SourceModule] = @SourceModule WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SourceModule = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSourceMessageId(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [SourceMessageId] = @SourceMessageId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SourceMessageId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmitenteFiscalDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [EmitenteFiscalDocumento] = @EmitenteFiscalDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmitenteFiscalDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTomadorDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [TomadorDocumento] = @TomadorDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TomadorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTransportadorDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [TransportadorDocumento] = @TransportadorDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TransportadorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRemetenteDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [RemetenteDocumento] = @RemetenteDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RemetenteDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDestinatarioDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [DestinatarioDocumento] = @DestinatarioDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                DestinatarioDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFInicio(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [UFInicio] = @UFInicio WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFInicio = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFFim(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [UFFim] = @UFFim WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFFim = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioInicioCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [MunicipioInicioCodigoIbge] = @MunicipioInicioCodigoIbge WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MunicipioInicioCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioFimCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [MunicipioFimCodigoIbge] = @MunicipioFimCodigoIbge WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MunicipioFimCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRNTRC(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [RNTRC] = @RNTRC WHERE [Id] = @Id ";
            this.Parameters = new
            {
                RNTRC = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePlacaVeiculo(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [PlacaVeiculo] = @PlacaVeiculo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PlacaVeiculo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFVeiculo(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [UFVeiculo] = @UFVeiculo WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UFVeiculo = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCondutorDocumento(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [CondutorDocumento] = @CondutorDocumento WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CondutorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCondutorNome(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [CondutorNome] = @CondutorNome WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CondutorNome = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateQuantidadeDocumentos(int id, int value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [QuantidadeDocumentos] = @QuantidadeDocumentos WHERE [Id] = @Id ";
            this.Parameters = new
            {
                QuantidadeDocumentos = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateValorCarga(int id, Decimal value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [ValorCarga] = @ValorCarga WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ValorCarga = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePesoBruto(int id, Decimal value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [PesoBruto] = @PesoBruto WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PesoBruto = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVolume(int id, Decimal value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [Volume] = @Volume WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Volume = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePendenciasJson(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [PendenciasJson] = @PendenciasJson WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PendenciasJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSnapshotJson(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [SnapshotJson] = @SnapshotJson WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SnapshotJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmissaoFiscalCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [EmissaoFiscalCorrelationId] = @EmissaoFiscalCorrelationId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmissaoFiscalCorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmissaoFiscalSagaId(int id, int value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [EmissaoFiscalSagaId] = @EmissaoFiscalSagaId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                EmissaoFiscalSagaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCriadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [CriadoEmUtc] = @CriadoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CriadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateAtualizadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [AtualizadoEmUtc] = @AtualizadoEmUtc WHERE [Id] = @Id ";
            this.Parameters = new
            {
                AtualizadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [EntradaFiscalContingencia] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEntradaFiscalContingenciaQuery(IEntradaFiscalContingenciaEntity EntradaFiscalContingencia)
        {
            this.Query = $@" DELETE FROM [EntradaFiscalContingencia] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = EntradaFiscalContingencia.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration