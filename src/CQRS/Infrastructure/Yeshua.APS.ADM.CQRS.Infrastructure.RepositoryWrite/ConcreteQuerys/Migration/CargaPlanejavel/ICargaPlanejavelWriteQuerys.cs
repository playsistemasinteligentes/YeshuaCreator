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

    public interface ICargaPlanejavelQueryWrite 
     {
        public QueryModel InserirCargaPlanejavelQuery(ICargaPlanejavelEntity CargaPlanejavel);
        public QueryModel UpdateCargaPlanejavelQuery(ICargaPlanejavelEntity CargaPlanejavel);
        QueryModel UpdateStatus(string cargaid, string value);
        QueryModel UpdateTransportadoraId(string cargaid, string value);
        QueryModel UpdateVeiculoId(string cargaid, string value);
        QueryModel UpdateTipoVeiculoId(string cargaid, int value);
        QueryModel UpdatePesoTeorico(string cargaid, Decimal value);
        QueryModel UpdateVolumeTeorico(string cargaid, Decimal value);
        QueryModel UpdateInicioJanelaEmbarque(string cargaid, DateTime value);
        QueryModel UpdateFimJanelaEmbarque(string cargaid, DateTime value);
        QueryModel UpdateEmbarqueAlvo(string cargaid, DateTime value);
        QueryModel UpdateQuantidadePedidos(string cargaid, int value);
        QueryModel UpdateAlertasResumo(string cargaid, string value);
        public QueryModel DeleteCargaPlanejavelQuery(ICargaPlanejavelEntity CargaPlanejavel);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration