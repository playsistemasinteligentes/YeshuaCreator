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

    public interface ICenarioPlanejamentoTransporteQueryWrite 
     {
        public QueryModel InserirCenarioPlanejamentoTransporteQuery(ICenarioPlanejamentoTransporteEntity CenarioPlanejamentoTransporte);
        public QueryModel UpdateCenarioPlanejamentoTransporteQuery(ICenarioPlanejamentoTransporteEntity CenarioPlanejamentoTransporte);
        QueryModel UpdateDescricao(string cenarioid, string value);
        QueryModel UpdateObjetivo(string cenarioid, string value);
        QueryModel UpdateQuantidadeCargas(string cenarioid, int value);
        QueryModel UpdateQuantidadePedidosNaoAtendidos(string cenarioid, int value);
        QueryModel UpdateCustoTotal(string cenarioid, Decimal value);
        QueryModel UpdateAderenciaCubagem(string cenarioid, Decimal value);
        QueryModel UpdateAtrasoPrevisto(string cenarioid, Decimal value);
        QueryModel UpdateAlertasResumo(string cenarioid, string value);
        public QueryModel DeleteCenarioPlanejamentoTransporteQuery(ICenarioPlanejamentoTransporteEntity CenarioPlanejamentoTransporte);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration