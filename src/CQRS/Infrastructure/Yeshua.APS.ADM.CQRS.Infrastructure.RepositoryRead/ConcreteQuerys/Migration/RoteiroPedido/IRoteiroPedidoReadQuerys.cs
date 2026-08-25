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
    public interface IRoteiroPedidoQueryRead 
    {
        public QueryModel RoteiroPedidoQuery(Command.Read.RoteiroPedidoReadCommand Command );
        public QueryModel RoteiroPedidoPedidoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroPedidoMaquinaIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroPedidoProdutoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByPedidoIdQuery(string value );
        public QueryModel ExistsByMaquinaIdQuery(string value );
        public QueryModel ExistsByProdutoIdQuery(string value );
        public QueryModel ExistsBySequenciaTransformacaoQuery(int value );
        public QueryModel ExistsByStatusCadastroQuery(string value );
        public QueryModel ExistsByTipoPlanejamentoQuery(string value );
        public QueryModel ExistsByCalendarioIdQuery(int value );
        public QueryModel ExistsByHierarquiaSequenciaTransformacaoQuery(Decimal value );
        public QueryModel ExistsByProximaSequenciaTransformacaoQuery(int value );
        public QueryModel ExistsByPerformanceQuery(Decimal value );
        public QueryModel ExistsByTempoSetupQuery(Decimal value );
        public QueryModel ExistsByTempoSetupAjusteQuery(Decimal value );
        public QueryModel ExistsByPecasPorPulsoQuery(Decimal value );
        public QueryModel ExistsByPrioridadeInformadaQuery(Decimal value );
        public QueryModel ExistsByStatusQuery(string value );
        public QueryModel ExistsByOperacoesQuery(string value );
        public QueryModel ExistsByExcecaoOperacoesQuery(string value );
        public QueryModel ExistsByLinhaDiretaQuery(string value );
        public QueryModel ExistsByAvaliaCustoQuery(int value );
        public QueryModel ExistsByPercentualInicioPassoAnteriorQuery(Decimal value );
        public QueryModel ExistsByMaquinaLarguraUtilQuery(Decimal value );
        public QueryModel ExistsByGrupoTipoQuery(Decimal value );
        public QueryModel ExistsByGrupoPerformanceMetroLinearQuery(Decimal value );
        public QueryModel FirstByPedidoIdQuery(string value );
        public QueryModel FirstByMaquinaIdQuery(string value );
        public QueryModel FirstByProdutoIdQuery(string value );
        public QueryModel FirstBySequenciaTransformacaoQuery(int value );
        public QueryModel FirstByStatusCadastroQuery(string value );
        public QueryModel FirstByTipoPlanejamentoQuery(string value );
        public QueryModel FirstByCalendarioIdQuery(int value );
        public QueryModel FirstByHierarquiaSequenciaTransformacaoQuery(Decimal value );
        public QueryModel FirstByProximaSequenciaTransformacaoQuery(int value );
        public QueryModel FirstByPerformanceQuery(Decimal value );
        public QueryModel FirstByTempoSetupQuery(Decimal value );
        public QueryModel FirstByTempoSetupAjusteQuery(Decimal value );
        public QueryModel FirstByPecasPorPulsoQuery(Decimal value );
        public QueryModel FirstByPrioridadeInformadaQuery(Decimal value );
        public QueryModel FirstByStatusQuery(string value );
        public QueryModel FirstByOperacoesQuery(string value );
        public QueryModel FirstByExcecaoOperacoesQuery(string value );
        public QueryModel FirstByLinhaDiretaQuery(string value );
        public QueryModel FirstByAvaliaCustoQuery(int value );
        public QueryModel FirstByPercentualInicioPassoAnteriorQuery(Decimal value );
        public QueryModel FirstByMaquinaLarguraUtilQuery(Decimal value );
        public QueryModel FirstByGrupoTipoQuery(Decimal value );
        public QueryModel FirstByGrupoPerformanceMetroLinearQuery(Decimal value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration