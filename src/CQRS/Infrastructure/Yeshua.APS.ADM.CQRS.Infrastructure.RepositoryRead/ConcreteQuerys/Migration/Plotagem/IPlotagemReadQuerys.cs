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
    public interface IPlotagemQueryRead 
    {
        public QueryModel PlotagemQuery(Command.Read.PlotagemReadCommand Command );
        public QueryModel PlotagemTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel PlotagemUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByPLO_IDQuery(int value );
        public QueryModel ExistsByPLO_NOMEQuery(string value );
        public QueryModel ExistsByPLO_DIMENSAOQuery(string value );
        public QueryModel ExistsByPLO_XQuery(string value );
        public QueryModel ExistsByPLO_YQuery(string value );
        public QueryModel ExistsByPLO_ZQuery(string value );
        public QueryModel ExistsByPLO_GRAFICOQuery(string value );
        public QueryModel ExistsByCON_IDQuery(int value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByPLO_IDQuery(int value );
        public QueryModel FirstByPLO_NOMEQuery(string value );
        public QueryModel FirstByPLO_DIMENSAOQuery(string value );
        public QueryModel FirstByPLO_XQuery(string value );
        public QueryModel FirstByPLO_YQuery(string value );
        public QueryModel FirstByPLO_ZQuery(string value );
        public QueryModel FirstByPLO_GRAFICOQuery(string value );
        public QueryModel FirstByCON_IDQuery(int value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration