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
    public interface IMunicipioQueryRead 
    {
        public QueryModel MunicipioQuery(Command.Read.MunicipioReadCommand Command );
        public QueryModel MunicipioTenantIDQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel MunicipioUserIdQuery(Command.Patterns.Command.SearchFKCommand Command );
        public QueryModel ExistsByMUN_IDQuery(string value );
        public QueryModel ExistsByMUN_NOMEQuery(string value );
        public QueryModel ExistsByUF_CODQuery(string value );
        public QueryModel ExistsByMUN_CODIGO_IBGEQuery(string value );
        public QueryModel ExistsByMUN_LATITUDEQuery(Decimal value );
        public QueryModel ExistsByMUN_LONGITUDEQuery(Decimal value );
        public QueryModel ExistsByMUN_ID_INTEGRACAO_ERPQuery(string value );
        public QueryModel ExistsByMUN_CODIGO_SIAFIQuery(string value );
        public QueryModel ExistsByMUN_CODIGO_CNPJQuery(string value );
        public QueryModel ExistsByMUN_DISTANCIA_KMQuery(Decimal value );
        public QueryModel ExistsByTenantIDQuery(int value );
        public QueryModel ExistsByDeletedQuery(bool value );
        public QueryModel ExistsByChangedQuery(DateTime value );
        public QueryModel ExistsByUserIdQuery(int value );
        public QueryModel FirstByMUN_IDQuery(string value );
        public QueryModel FirstByMUN_NOMEQuery(string value );
        public QueryModel FirstByUF_CODQuery(string value );
        public QueryModel FirstByMUN_CODIGO_IBGEQuery(string value );
        public QueryModel FirstByMUN_LATITUDEQuery(Decimal value );
        public QueryModel FirstByMUN_LONGITUDEQuery(Decimal value );
        public QueryModel FirstByMUN_ID_INTEGRACAO_ERPQuery(string value );
        public QueryModel FirstByMUN_CODIGO_SIAFIQuery(string value );
        public QueryModel FirstByMUN_CODIGO_CNPJQuery(string value );
        public QueryModel FirstByMUN_DISTANCIA_KMQuery(Decimal value );
        public QueryModel FirstByTenantIDQuery(int value );
        public QueryModel FirstByDeletedQuery(bool value );
        public QueryModel FirstByChangedQuery(DateTime value );
        public QueryModel FirstByUserIdQuery(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryReadMigration