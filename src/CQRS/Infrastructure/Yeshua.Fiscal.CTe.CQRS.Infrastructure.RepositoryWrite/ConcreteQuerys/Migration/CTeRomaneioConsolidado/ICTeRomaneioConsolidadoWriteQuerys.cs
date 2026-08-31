// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Shered.DB;
using Dominio.Entitys;
namespace IQuery.Write
{

    public interface ICTeRomaneioConsolidadoQueryWrite 
     {
        public QueryModel InserirCTeRomaneioConsolidadoQuery(ICTeRomaneioConsolidadoEntity CTeRomaneioConsolidado);
        public QueryModel UpdateCTeRomaneioConsolidadoQuery(ICTeRomaneioConsolidadoEntity CTeRomaneioConsolidado);
        QueryModel UpdateEntradaOficialId(int id, int value);
        QueryModel UpdateCorrelationId(int id, string value);
        QueryModel UpdateRomaneioId(int id, string value);
        QueryModel UpdateCargaId(int id, string value);
        QueryModel UpdateConsolidadoEmUtc(int id, DateTime value);
        QueryModel UpdateUFInicio(int id, string value);
        QueryModel UpdateUFFim(int id, string value);
        QueryModel UpdateMunicipioInicioCodigoIbge(int id, string value);
        QueryModel UpdateMunicipioFimCodigoIbge(int id, string value);
        QueryModel UpdateEmitenteDocumento(int id, string value);
        QueryModel UpdateTomadorDocumento(int id, string value);
        QueryModel UpdateRotaSnapshotJson(int id, string value);
        QueryModel UpdateCargaSnapshotJson(int id, string value);
        QueryModel UpdatePreferenciasFiscaisJson(int id, string value);
        QueryModel UpdateStatus(int id, int value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteCTeRomaneioConsolidadoQuery(ICTeRomaneioConsolidadoEntity CTeRomaneioConsolidado);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration