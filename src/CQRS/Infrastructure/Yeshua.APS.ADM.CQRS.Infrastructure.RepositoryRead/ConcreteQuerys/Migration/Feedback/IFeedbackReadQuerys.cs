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
    public interface IFeedbackQueryRead 
    {
        public QueryModel FeedbackQuery(Command.Read.FeedbackReadCommand Command );
        public QueryModel FeedbackOcorrenciaIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel FeedbackTurnoIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel FeedbackTurmaIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel FeedbackUsuarioIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel FeedbackTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel FeedbackUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByDataInicialQuery(DateTime value );
        public QueryModel ExistsByDatafinalQuery(DateTime value );
        public QueryModel ExistsByMaquinaIdQuery(string value );
        public QueryModel ExistsByOcorrenciaIdQuery(string value );
        public QueryModel ExistsByTurnoIdQuery(string value );
        public QueryModel ExistsByTurmaIdQuery(string value );
        public QueryModel ExistsByUsuarioIdQuery(int value );
        public QueryModel ExistsByOrderIdQuery(string value );
        public QueryModel ExistsByProdutoIdQuery(string value );
        public QueryModel ExistsByObservacoesQuery(string value );
        public QueryModel ExistsByGrupoQuery(Decimal value );
        public QueryModel ExistsByDiaTurmaQuery(string value );
        public QueryModel ExistsBySequenciaTransformacaoQuery(int value );
        public QueryModel ExistsBySequenciaRepeticaoQuery(int value );
        public QueryModel ExistsByQuantidadePulsosQuery(Decimal value );
        public QueryModel ExistsByQuantidadePecasPorPulsoQuery(Decimal value );
        public QueryModel ExistsByFEE_QTD_TOTAL_PRODUCAO_AJUSTADAQuery(Decimal value );
        public QueryModel ExistsByBOL_IDQuery(string value );
        public QueryModel ExistsByCOR_SEQUENCIAQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByDataInicialQuery(DateTime value );
        public QueryModel FirstByDatafinalQuery(DateTime value );
        public QueryModel FirstByMaquinaIdQuery(string value );
        public QueryModel FirstByOcorrenciaIdQuery(string value );
        public QueryModel FirstByTurnoIdQuery(string value );
        public QueryModel FirstByTurmaIdQuery(string value );
        public QueryModel FirstByUsuarioIdQuery(int value );
        public QueryModel FirstByOrderIdQuery(string value );
        public QueryModel FirstByProdutoIdQuery(string value );
        public QueryModel FirstByObservacoesQuery(string value );
        public QueryModel FirstByGrupoQuery(Decimal value );
        public QueryModel FirstByDiaTurmaQuery(string value );
        public QueryModel FirstBySequenciaTransformacaoQuery(int value );
        public QueryModel FirstBySequenciaRepeticaoQuery(int value );
        public QueryModel FirstByQuantidadePulsosQuery(Decimal value );
        public QueryModel FirstByQuantidadePecasPorPulsoQuery(Decimal value );
        public QueryModel FirstByFEE_QTD_TOTAL_PRODUCAO_AJUSTADAQuery(Decimal value );
        public QueryModel FirstByBOL_IDQuery(string value );
        public QueryModel FirstByCOR_SEQUENCIAQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration