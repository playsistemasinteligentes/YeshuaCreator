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
    public interface IRoteiroQueryRead 
    {
        public QueryModel RoteiroQuery(Command.Read.RoteiroReadCommand Command );
        public QueryModel RoteiroMaquinaIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroProdutoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroGrupoMaquinaIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroTemplateDeTestesIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel RoteiroUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMaquinaIdQuery(string value );
        public QueryModel ExistsByProdutoIdQuery(string value );
        public QueryModel ExistsBySequenciaTransformacaoQuery(int value );
        public QueryModel ExistsByGrupoMaquinaIdQuery(string value );
        public QueryModel ExistsByPecasPorPulsoQuery(Decimal value );
        public QueryModel ExistsByPrioridadeInformadaQuery(Decimal value );
        public QueryModel ExistsByAcaoQuery(string value );
        public QueryModel ExistsByPerformanceQuery(Decimal value );
        public QueryModel ExistsByTempoSetupQuery(Decimal value );
        public QueryModel ExistsByTempoSetupAjusteQuery(Decimal value );
        public QueryModel ExistsByProximaSequenciaTransformacaoQuery(int value );
        public QueryModel ExistsByStatusQuery(string value );
        public QueryModel ExistsByHierarquiaSequenciaTransformacaoQuery(Decimal value );
        public QueryModel ExistsByAvaliaCustoQuery(int value );
        public QueryModel ExistsByOperacoesQuery(string value );
        public QueryModel ExistsByExcecaoOperacoesQuery(string value );
        public QueryModel ExistsByPercentualInicioPassoAnteriorQuery(Decimal value );
        public QueryModel ExistsByLinhaDiretaQuery(string value );
        public QueryModel ExistsByTemplateDeTestesIdQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMaquinaIdQuery(string value );
        public QueryModel FirstByProdutoIdQuery(string value );
        public QueryModel FirstBySequenciaTransformacaoQuery(int value );
        public QueryModel FirstByGrupoMaquinaIdQuery(string value );
        public QueryModel FirstByPecasPorPulsoQuery(Decimal value );
        public QueryModel FirstByPrioridadeInformadaQuery(Decimal value );
        public QueryModel FirstByAcaoQuery(string value );
        public QueryModel FirstByPerformanceQuery(Decimal value );
        public QueryModel FirstByTempoSetupQuery(Decimal value );
        public QueryModel FirstByTempoSetupAjusteQuery(Decimal value );
        public QueryModel FirstByProximaSequenciaTransformacaoQuery(int value );
        public QueryModel FirstByStatusQuery(string value );
        public QueryModel FirstByHierarquiaSequenciaTransformacaoQuery(Decimal value );
        public QueryModel FirstByAvaliaCustoQuery(int value );
        public QueryModel FirstByOperacoesQuery(string value );
        public QueryModel FirstByExcecaoOperacoesQuery(string value );
        public QueryModel FirstByPercentualInicioPassoAnteriorQuery(Decimal value );
        public QueryModel FirstByLinhaDiretaQuery(string value );
        public QueryModel FirstByTemplateDeTestesIdQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration