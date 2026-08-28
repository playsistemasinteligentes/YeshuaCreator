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
    public interface IMedidasTesteQueryRead 
    {
        public QueryModel MedidasTesteQuery(Command.Read.MedidasTesteReadCommand Command );
        public QueryModel MedidasTesteTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MedidasTesteUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByIdQuery(int value );
        public QueryModel ExistsByMDT_IDQuery(int value );
        public QueryModel ExistsByMDT_DESCQuery(string value );
        public QueryModel ExistsByMDT_VALOR_ESPERADOQuery(Decimal value );
        public QueryModel ExistsByMDT_ENCONTRADOQuery(Decimal value );
        public QueryModel ExistsByUNI_IDQuery(string value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByIdQuery(int value );
        public QueryModel FirstByMDT_IDQuery(int value );
        public QueryModel FirstByMDT_DESCQuery(string value );
        public QueryModel FirstByMDT_VALOR_ESPERADOQuery(Decimal value );
        public QueryModel FirstByMDT_ENCONTRADOQuery(Decimal value );
        public QueryModel FirstByUNI_IDQuery(string value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration