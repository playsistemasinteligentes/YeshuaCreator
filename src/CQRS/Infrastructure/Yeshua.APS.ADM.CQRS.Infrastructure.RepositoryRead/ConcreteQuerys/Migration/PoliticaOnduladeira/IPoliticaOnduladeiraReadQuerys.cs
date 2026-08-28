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
    public interface IPoliticaOnduladeiraQueryRead 
    {
        public QueryModel PoliticaOnduladeiraQuery(Command.Read.PoliticaOnduladeiraReadCommand Command );
        public QueryModel PoliticaOnduladeiraTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PoliticaOnduladeiraUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByPOL_IDQuery(int value );
        public QueryModel ExistsByPOL_NIVELQuery(int value );
        public QueryModel ExistsByPOL_PROMOCAOQuery(int value );
        public QueryModel ExistsByPOL_DIAS_ANTECIPACAOQuery(int value );
        public QueryModel ExistsByPOL_METROS_LINEARESQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByPOL_IDQuery(int value );
        public QueryModel FirstByPOL_NIVELQuery(int value );
        public QueryModel FirstByPOL_PROMOCAOQuery(int value );
        public QueryModel FirstByPOL_DIAS_ANTECIPACAOQuery(int value );
        public QueryModel FirstByPOL_METROS_LINEARESQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration