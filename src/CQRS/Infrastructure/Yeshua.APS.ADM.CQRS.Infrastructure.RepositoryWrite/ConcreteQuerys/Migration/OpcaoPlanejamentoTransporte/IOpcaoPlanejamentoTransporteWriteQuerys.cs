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

    public interface IOpcaoPlanejamentoTransporteQueryWrite 
     {
        public QueryModel InserirOpcaoPlanejamentoTransporteQuery(IOpcaoPlanejamentoTransporteEntity OpcaoPlanejamentoTransporte);
        public QueryModel UpdateOpcaoPlanejamentoTransporteQuery(IOpcaoPlanejamentoTransporteEntity OpcaoPlanejamentoTransporte);
        QueryModel UpdateGrupoDecisaoId(string opcaoid, string value);
        QueryModel UpdatePeso(string opcaoid, Decimal value);
        QueryModel UpdateVolume(string opcaoid, Decimal value);
        QueryModel UpdateCustoEstimado(string opcaoid, Decimal value);
        QueryModel UpdateAderenciaCubagem(string opcaoid, Decimal value);
        QueryModel UpdateAderenciaJanelaEntrega(string opcaoid, Decimal value);
        QueryModel UpdateRiscoResumo(string opcaoid, string value);
        QueryModel UpdatePedidosResumo(string opcaoid, string value);
        QueryModel UpdateOpcoesConflitantesResumo(string opcaoid, string value);
        public QueryModel DeleteOpcaoPlanejamentoTransporteQuery(IOpcaoPlanejamentoTransporteEntity OpcaoPlanejamentoTransporte);
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration