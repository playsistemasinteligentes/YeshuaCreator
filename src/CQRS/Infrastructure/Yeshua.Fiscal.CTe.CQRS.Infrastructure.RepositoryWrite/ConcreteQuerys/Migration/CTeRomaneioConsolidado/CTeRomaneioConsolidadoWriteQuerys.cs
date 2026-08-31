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
    public class CTeRomaneioConsolidadoQueryWrite : QueryBase, ICTeRomaneioConsolidadoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CTeRomaneioConsolidadoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCTeRomaneioConsolidadoQuery(ICTeRomaneioConsolidadoEntity CTeRomaneioConsolidado)
        {
            this.Query = $@" INSERT INTO CTeRomaneioConsolidado (EntradaOficialId, CorrelationId, RomaneioId, CargaId, ConsolidadoEmUtc, UFInicio, UFFim, MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge, EmitenteDocumento, TomadorDocumento, RotaSnapshotJson, CargaSnapshotJson, PreferenciasFiscaisJson, Status, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@EntradaOficialId, @CorrelationId, @RomaneioId, @CargaId, @ConsolidadoEmUtc, @UFInicio, @UFFim, @MunicipioInicioCodigoIbge, @MunicipioFimCodigoIbge, @EmitenteDocumento, @TomadorDocumento, @RotaSnapshotJson, @CargaSnapshotJson, @PreferenciasFiscaisJson, @Status, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                EntradaOficialId = CTeRomaneioConsolidado.EntradaOficialId,
                CorrelationId = CTeRomaneioConsolidado.CorrelationId,
                RomaneioId = CTeRomaneioConsolidado.RomaneioId,
                CargaId = CTeRomaneioConsolidado.CargaId,
                ConsolidadoEmUtc = CTeRomaneioConsolidado.ConsolidadoEmUtc,
                UFInicio = CTeRomaneioConsolidado.UFInicio,
                UFFim = CTeRomaneioConsolidado.UFFim,
                MunicipioInicioCodigoIbge = CTeRomaneioConsolidado.MunicipioInicioCodigoIbge,
                MunicipioFimCodigoIbge = CTeRomaneioConsolidado.MunicipioFimCodigoIbge,
                EmitenteDocumento = CTeRomaneioConsolidado.EmitenteDocumento,
                TomadorDocumento = CTeRomaneioConsolidado.TomadorDocumento,
                RotaSnapshotJson = CTeRomaneioConsolidado.RotaSnapshotJson,
                CargaSnapshotJson = CTeRomaneioConsolidado.CargaSnapshotJson,
                PreferenciasFiscaisJson = CTeRomaneioConsolidado.PreferenciasFiscaisJson,
                Status = CTeRomaneioConsolidado.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCTeRomaneioConsolidadoQuery(ICTeRomaneioConsolidadoEntity CTeRomaneioConsolidado)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET EntradaOficialId = @EntradaOficialId, CorrelationId = @CorrelationId, RomaneioId = @RomaneioId, CargaId = @CargaId, ConsolidadoEmUtc = @ConsolidadoEmUtc, UFInicio = @UFInicio, UFFim = @UFFim, MunicipioInicioCodigoIbge = @MunicipioInicioCodigoIbge, MunicipioFimCodigoIbge = @MunicipioFimCodigoIbge, EmitenteDocumento = @EmitenteDocumento, TomadorDocumento = @TomadorDocumento, RotaSnapshotJson = @RotaSnapshotJson, CargaSnapshotJson = @CargaSnapshotJson, PreferenciasFiscaisJson = @PreferenciasFiscaisJson, Status = @Status, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                EntradaOficialId = CTeRomaneioConsolidado.EntradaOficialId,
                CorrelationId = CTeRomaneioConsolidado.CorrelationId,
                RomaneioId = CTeRomaneioConsolidado.RomaneioId,
                CargaId = CTeRomaneioConsolidado.CargaId,
                ConsolidadoEmUtc = CTeRomaneioConsolidado.ConsolidadoEmUtc,
                UFInicio = CTeRomaneioConsolidado.UFInicio,
                UFFim = CTeRomaneioConsolidado.UFFim,
                MunicipioInicioCodigoIbge = CTeRomaneioConsolidado.MunicipioInicioCodigoIbge,
                MunicipioFimCodigoIbge = CTeRomaneioConsolidado.MunicipioFimCodigoIbge,
                EmitenteDocumento = CTeRomaneioConsolidado.EmitenteDocumento,
                TomadorDocumento = CTeRomaneioConsolidado.TomadorDocumento,
                RotaSnapshotJson = CTeRomaneioConsolidado.RotaSnapshotJson,
                CargaSnapshotJson = CTeRomaneioConsolidado.CargaSnapshotJson,
                PreferenciasFiscaisJson = CTeRomaneioConsolidado.PreferenciasFiscaisJson,
                Status = CTeRomaneioConsolidado.Status,
                Changed = CTeRomaneioConsolidado.Changed,
                UserId = _executionContext.UserId,
                Id = CTeRomaneioConsolidado.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEntradaOficialId(int id, int value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET EntradaOficialId = @EntradaOficialId WHERE Id = @Id ";
            this.Parameters = new
            {
                EntradaOficialId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorrelationId(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET CorrelationId = @CorrelationId WHERE Id = @Id ";
            this.Parameters = new
            {
                CorrelationId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRomaneioId(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET RomaneioId = @RomaneioId WHERE Id = @Id ";
            this.Parameters = new
            {
                RomaneioId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaId(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET CargaId = @CargaId WHERE Id = @Id ";
            this.Parameters = new
            {
                CargaId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateConsolidadoEmUtc(int id, DateTime value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET ConsolidadoEmUtc = @ConsolidadoEmUtc WHERE Id = @Id ";
            this.Parameters = new
            {
                ConsolidadoEmUtc = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFInicio(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET UFInicio = @UFInicio WHERE Id = @Id ";
            this.Parameters = new
            {
                UFInicio = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUFFim(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET UFFim = @UFFim WHERE Id = @Id ";
            this.Parameters = new
            {
                UFFim = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioInicioCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET MunicipioInicioCodigoIbge = @MunicipioInicioCodigoIbge WHERE Id = @Id ";
            this.Parameters = new
            {
                MunicipioInicioCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMunicipioFimCodigoIbge(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET MunicipioFimCodigoIbge = @MunicipioFimCodigoIbge WHERE Id = @Id ";
            this.Parameters = new
            {
                MunicipioFimCodigoIbge = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEmitenteDocumento(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET EmitenteDocumento = @EmitenteDocumento WHERE Id = @Id ";
            this.Parameters = new
            {
                EmitenteDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTomadorDocumento(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET TomadorDocumento = @TomadorDocumento WHERE Id = @Id ";
            this.Parameters = new
            {
                TomadorDocumento = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRotaSnapshotJson(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET RotaSnapshotJson = @RotaSnapshotJson WHERE Id = @Id ";
            this.Parameters = new
            {
                RotaSnapshotJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaSnapshotJson(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET CargaSnapshotJson = @CargaSnapshotJson WHERE Id = @Id ";
            this.Parameters = new
            {
                CargaSnapshotJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePreferenciasFiscaisJson(int id, string value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET PreferenciasFiscaisJson = @PreferenciasFiscaisJson WHERE Id = @Id ";
            this.Parameters = new
            {
                PreferenciasFiscaisJson = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(int id, int value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET Status = @Status WHERE Id = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE CTeRomaneioConsolidado SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCTeRomaneioConsolidadoQuery(ICTeRomaneioConsolidadoEntity CTeRomaneioConsolidado)
        {
            this.Query = $@" DELETE FROM CTeRomaneioConsolidado WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = CTeRomaneioConsolidado.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration