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
    public interface ICenarioPlanejamentoTransporteQueryRead 
    {
        public QueryModel CenarioPlanejamentoTransporteQuery(Command.Read.CenarioPlanejamentoTransporteReadCommand Command );
        public QueryModel ExistsByCenarioIdQuery(string value );
        public QueryModel ExistsByDescricaoQuery(string value );
        public QueryModel ExistsByObjetivoQuery(string value );
        public QueryModel ExistsByQuantidadeCargasQuery(int value );
        public QueryModel ExistsByQuantidadePedidosNaoAtendidosQuery(int value );
        public QueryModel ExistsByCustoTotalQuery(Decimal value );
        public QueryModel ExistsByAderenciaCubagemQuery(Decimal value );
        public QueryModel ExistsByAtrasoPrevistoQuery(Decimal value );
        public QueryModel ExistsByAlertasResumoQuery(string value );
        public QueryModel FirstByCenarioIdQuery(string value );
        public QueryModel FirstByDescricaoQuery(string value );
        public QueryModel FirstByObjetivoQuery(string value );
        public QueryModel FirstByQuantidadeCargasQuery(int value );
        public QueryModel FirstByQuantidadePedidosNaoAtendidosQuery(int value );
        public QueryModel FirstByCustoTotalQuery(Decimal value );
        public QueryModel FirstByAderenciaCubagemQuery(Decimal value );
        public QueryModel FirstByAtrasoPrevistoQuery(Decimal value );
        public QueryModel FirstByAlertasResumoQuery(string value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration