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
    public interface IT_PREFERENCIASQueryRead 
    {
        public QueryModel T_PREFERENCIASQuery(Command.Read.T_PREFERENCIASReadCommand Command );
        public QueryModel T_PREFERENCIASTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel T_PREFERENCIASUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByPRE_IDQuery(int value );
        public QueryModel ExistsByPRE_DESCRICAOQuery(string value );
        public QueryModel ExistsByPRE_NAMESPACEQuery(string value );
        public QueryModel ExistsByPRE_TIPOQuery(string value );
        public QueryModel ExistsByPRE_VALORQuery(string value );
        public QueryModel ExistsByUSE_IDQuery(int value );
        public QueryModel ExistsByPER_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByPRE_IDQuery(int value );
        public QueryModel FirstByPRE_DESCRICAOQuery(string value );
        public QueryModel FirstByPRE_NAMESPACEQuery(string value );
        public QueryModel FirstByPRE_TIPOQuery(string value );
        public QueryModel FirstByPRE_VALORQuery(string value );
        public QueryModel FirstByUSE_IDQuery(int value );
        public QueryModel FirstByPER_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration