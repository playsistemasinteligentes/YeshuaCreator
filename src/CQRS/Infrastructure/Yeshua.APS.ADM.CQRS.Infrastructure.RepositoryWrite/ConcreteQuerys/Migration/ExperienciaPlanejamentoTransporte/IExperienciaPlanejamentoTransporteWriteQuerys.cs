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

    public interface IExperienciaPlanejamentoTransporteQueryWrite 
     {
        public QueryModel InserirExperienciaPlanejamentoTransporteQuery(IExperienciaPlanejamentoTransporteEntity ExperienciaPlanejamentoTransporte);
        public QueryModel UpdateExperienciaPlanejamentoTransporteQuery(IExperienciaPlanejamentoTransporteEntity ExperienciaPlanejamentoTransporte);
        QueryModel UpdateTipo(int id, int value);
        QueryModel UpdateReferencia(int id, string value);
        QueryModel UpdatePedidoId(int id, string value);
        QueryModel UpdateClienteId(int id, string value);
        QueryModel UpdateMunicipio(int id, string value);
        QueryModel UpdateRegiao(int id, string value);
        QueryModel UpdateRotaId(int id, string value);
        QueryModel UpdatePeso(int id, Decimal value);
        QueryModel UpdateVolume(int id, Decimal value);
        QueryModel UpdateObservacao(int id, string value);
        QueryModel UpdateCriadoEm(int id, DateTime value);
        QueryModel UpdateCriadoPor(int id, string value);
        QueryModel UpdateTenantID(int id, int value);
        QueryModel UpdateDeleted(int id, bool value);
        QueryModel UpdateChanged(int id, DateTime value);
        QueryModel UpdateUserId(int id, int value);
        public QueryModel DeleteExperienciaPlanejamentoTransporteQuery(IExperienciaPlanejamentoTransporteEntity ExperienciaPlanejamentoTransporte);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration