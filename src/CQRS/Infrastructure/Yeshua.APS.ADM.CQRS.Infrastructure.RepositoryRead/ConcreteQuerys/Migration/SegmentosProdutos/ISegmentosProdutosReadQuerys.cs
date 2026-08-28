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
    public interface ISegmentosProdutosQueryRead 
    {
        public QueryModel SegmentosProdutosQuery(Command.Read.SegmentosProdutosReadCommand Command );
        public QueryModel SegmentosProdutosTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel SegmentosProdutosUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByGRS_IDQuery(string value );
        public QueryModel ExistsByPRO_IDQuery(string value );
        public QueryModel ExistsBySEG_IDQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByGRS_IDQuery(string value );
        public QueryModel FirstByPRO_IDQuery(string value );
        public QueryModel FirstBySEG_IDQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration