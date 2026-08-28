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
    public interface IUnidade_UnidadeQueryRead 
    {
        public QueryModel Unidade_UnidadeQuery(Command.Read.Unidade_UnidadeReadCommand Command );
        public QueryModel Unidade_UnidadeTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel Unidade_UnidadeUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByUNI_IDQuery(int value );
        public QueryModel ExistsByUNI_DESCRICAOQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByUNI_IDQuery(int value );
        public QueryModel FirstByUNI_DESCRICAOQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration