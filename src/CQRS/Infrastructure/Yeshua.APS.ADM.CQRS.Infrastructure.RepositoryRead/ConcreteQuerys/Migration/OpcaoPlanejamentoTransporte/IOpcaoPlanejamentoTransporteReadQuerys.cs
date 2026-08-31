// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration
// </yeshua>

using Shered.DB;
namespace IQuery.Read
{
    public interface IOpcaoPlanejamentoTransporteQueryRead 
    {
        public QueryModel OpcaoPlanejamentoTransporteQuery(Command.Read.OpcaoPlanejamentoTransporteReadCommand Command );
        public QueryModel ExistsByOpcaoIdQuery(string value );
        public QueryModel ExistsByGrupoDecisaoIdQuery(string value );
        public QueryModel ExistsByPesoQuery(Decimal value );
        public QueryModel ExistsByVolumeQuery(Decimal value );
        public QueryModel ExistsByCustoEstimadoQuery(Decimal value );
        public QueryModel ExistsByAderenciaCubagemQuery(Decimal value );
        public QueryModel ExistsByAderenciaJanelaEntregaQuery(Decimal value );
        public QueryModel ExistsByRiscoResumoQuery(string value );
        public QueryModel ExistsByPedidosResumoQuery(string value );
        public QueryModel ExistsByOpcoesConflitantesResumoQuery(string value );
        public QueryModel FirstByOpcaoIdQuery(string value );
        public QueryModel FirstByGrupoDecisaoIdQuery(string value );
        public QueryModel FirstByPesoQuery(Decimal value );
        public QueryModel FirstByVolumeQuery(Decimal value );
        public QueryModel FirstByCustoEstimadoQuery(Decimal value );
        public QueryModel FirstByAderenciaCubagemQuery(Decimal value );
        public QueryModel FirstByAderenciaJanelaEntregaQuery(Decimal value );
        public QueryModel FirstByRiscoResumoQuery(string value );
        public QueryModel FirstByPedidosResumoQuery(string value );
        public QueryModel FirstByOpcoesConflitantesResumoQuery(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration